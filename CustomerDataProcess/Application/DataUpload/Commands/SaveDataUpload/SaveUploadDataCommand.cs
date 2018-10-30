using Application.BusinessToBusiness.Queries;
using Application.BusinessToCustomers.Queries;
using Application.Common;
using Application.CustomerData.Queries;
using Application.DataUpload.Queries.GetUpLoadDataType;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class SaveUploadDataCommand : ISaveUploadDataCommand
    {
        private readonly IFileToDataModel _CustomerDataFileToDataModel;
        private readonly ISaveCustomerData _saveCustomerData;
        private readonly IBusinessToBusinessFileToDataModel _businessToBusinessFileToDataModel;
        private readonly IBusinessToCustomerFileToDataModel _businessToCustomerFileToDataModel;
        private readonly ISaveBusinessToBusiness _saveBusinessToBusiness;
        private readonly IValidateEntiry _validateEntiry;
        private readonly IValidateBusinessCategoruEntiry _validateBusinessCategoruEntiry;
        private readonly ISaveBusinessToCustomer _saveBusinessToCustomer;
        private readonly IGetCustomerPhone _getCustomerPhone;
        private readonly IGetBusinessToCustomerPhone _getBusinessToCustomerPhone;
        private readonly IGetBusinesstoBusinessPhone _getBusinesstoBusinessPhone;
        //private IUploadProcess[] uploadProcesses = new IUploadProcess[] {
        //    new BusinessToCustomerUploadProcess(new BusinessToCustomerFileToDataModel(),        //new SaveCustomerData()),

        //};
        private readonly IGetNewRequestId _getNewRequestId;
        private readonly ISaveBusinessToBusinessTags _saveBusinessToBusinessTags;
        private readonly ISaveBusinessToCustomerTags _saveBusinessToCustomerTags;
        private readonly ISaveCustomerDataTags _saveCustomerDataTags;
        public SaveUploadDataCommand(IFileToDataModel fileToDataModel,
            ISaveCustomerData saveCustomerData,
            IBusinessToBusinessFileToDataModel businessToBusinessFileToDataModel,
            IBusinessToCustomerFileToDataModel businessToCustomerFileToDataModel,
            ISaveBusinessToBusiness saveBusinessToBusiness,
            IValidateEntiry validateEntiry,
            IValidateBusinessCategoruEntiry validateBusinessCategoruEntiry,
            ISaveBusinessToCustomer saveBusinessToCustomer,
            IGetCustomerPhone getCustomerPhone,
            IGetBusinessToCustomerPhone getBusinessToCustomerPhone,
            IGetBusinesstoBusinessPhone getBusinesstoBusinessPhone,
            IGetNewRequestId getNewRequestId,
            ISaveBusinessToBusinessTags saveBusinessToBusinessTags,
            ISaveBusinessToCustomerTags saveBusinessToCustomerTags,
            ISaveCustomerDataTags saveCustomerDataTags)
        {
            _CustomerDataFileToDataModel = fileToDataModel;
            _saveCustomerData = saveCustomerData;
            _businessToBusinessFileToDataModel = businessToBusinessFileToDataModel;
            _businessToCustomerFileToDataModel = businessToCustomerFileToDataModel;
            _saveBusinessToBusiness = saveBusinessToBusiness;
            _validateEntiry = validateEntiry;
            _validateBusinessCategoruEntiry = validateBusinessCategoruEntiry;
            _saveBusinessToCustomer = saveBusinessToCustomer;
            _getCustomerPhone = getCustomerPhone;
            _getBusinessToCustomerPhone = getBusinessToCustomerPhone;
            _getBusinesstoBusinessPhone = getBusinesstoBusinessPhone;
            _getNewRequestId = getNewRequestId;
            _saveBusinessToBusinessTags = saveBusinessToBusinessTags;
            _saveBusinessToCustomerTags = saveBusinessToCustomerTags;
            _saveCustomerDataTags = saveCustomerDataTags;
        }

        public UploadSaveStatus Upload(SaveDataModel saveDataModel)
        {
            var requestId = _getNewRequestId.Get(saveDataModel.UploadTypeId);
            var tags = SplitSting.Split(saveDataModel.Tags, ',');

            var uploadStatus = new UploadSaveStatus();
            if (saveDataModel.UploadTypeId == (int)UploadType.BusinessToBusiness)
            {
                var businessToBusinessData = _businessToBusinessFileToDataModel.ReadFileData(saveDataModel);
                var businessToBusiness = businessToBusinessData.Item1;
                uploadStatus.TotalRows = businessToBusinessData.Item2;

                // Check business category validation
                // Ceck phone number validation
                //var phone = businessToBusiness.Select(x => x.Phone1).Where(x => !string.IsNullOrWhiteSpace(x)).AsEnumerable<string>();
                var numbers = _getBusinesstoBusinessPhone.Get();
                businessToBusiness = businessToBusiness.Except(numbers, x => x.MobileNew, y => y).ToList();
                numbers = null;
                if (businessToBusiness.Count() > 0)
                {
                    // validate Business category
                    var categoryName = businessToBusiness.Select(x => x.CategoryId.Value).AsEnumerable<int>();
                    var unmappedCategory = _validateBusinessCategoruEntiry.Validate(categoryName).ToList<int>();
                    var validBusinessToBusiness = businessToBusiness.Join(unmappedCategory,
                        x => x.CategoryId,
                        y => y,
                        (x, y) => x).AsEnumerable<BusinessToBusinesModel>();
                    uploadStatus.UploadedRows = validBusinessToBusiness.Count(); // number of rows going to update
                    if (validBusinessToBusiness.Count() > 0)
                    {
                        uploadStatus.IsUploaded = _saveBusinessToBusiness.Save(validBusinessToBusiness, requestId);
                        _saveBusinessToBusinessTags.Save(requestId, tags);
                    }
                }
                // status message update
                if (uploadStatus.TotalRows > uploadStatus.UploadedRows)
                {
                    uploadStatus.StatusMessage = "Some business category doesn't mapped or duplicate phone numers exist";
                }
            }
            else if (saveDataModel.UploadTypeId == (int)UploadType.BusinessToCustomer)
            {
                var businessToCustomer = _businessToCustomerFileToDataModel.ReadFileData(saveDataModel);
                uploadStatus.TotalRows = businessToCustomer.Item2;
                var dbNumbers = _getBusinessToCustomerPhone.Get();
                var filteredData = businessToCustomer.Item1.Except(dbNumbers, x => x.MobileNew, y => y).ToList();
                dbNumbers = null;
                uploadStatus.UploadedRows = filteredData.Count(); // number of rows going to update
                if (uploadStatus.UploadedRows > 0) { 
                    uploadStatus.IsUploaded = _saveBusinessToCustomer.Save(filteredData, requestId);
                _saveBusinessToCustomerTags.Save(requestId, tags);
            }
                // status message update
                if (uploadStatus.TotalRows > uploadStatus.UploadedRows)
                {
                    uploadStatus.StatusMessage = "Duplicate phone numers exist";
                }
            }
            else if (saveDataModel.UploadTypeId == (int)UploadType.CustomerData)
            {
                var customerData = _CustomerDataFileToDataModel.ReadFileData(saveDataModel);
                uploadStatus.TotalRows = customerData.Item2;

                // Mobile number filter
                var dbNumbers = _getCustomerPhone.Get();
                var filteredData = customerData.Item1.Except(dbNumbers, x => x.Numbers, y => y).ToList();
                dbNumbers = null; // Make it as empty
                uploadStatus.UploadedRows = filteredData.Count(); // number of rows going to update
                if (uploadStatus.UploadedRows > 0)
                {
                    uploadStatus.IsUploaded = _saveCustomerData.Save(filteredData, requestId);
                    _saveCustomerDataTags.Save(requestId, tags);
                }                   
                // status message update
                if (uploadStatus.TotalRows > uploadStatus.UploadedRows)
                {
                    uploadStatus.StatusMessage = "Duplicate phone numers exist";
                }
            }
            else
            {
                uploadStatus.IsUploaded = false;
                uploadStatus.StatusMessage = "Please upload valid file";
            }
            return uploadStatus;
        }
    }

    public static class LinqExtensions
    {
        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, bool> comparer)
        {
            return first.Where(x => second.Count(y => comparer(x, y)) == 0);
        }

        public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, bool> comparer)
        {
            return first.Where(x => second.Count(y => comparer(x, y)) == 1);
        }

        public static IEnumerable<TSource> Except<TSource, TThat, TKey>(
            this IEnumerable<TSource> first,
            IEnumerable<TThat> second,
            Func<TSource, TKey> firstKey,
            Func<TThat, TKey> secondKey)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");

            var set = new HashSet<TKey>();
            foreach (var element in second)
            {
                set.Add(secondKey(element));
            }

            foreach (var element in first)
            {
                if (set.Add(firstKey(element)))
                {
                    set.Remove(firstKey(element));
                    yield return element;
                }
            }
        }

        public static IEnumerable<TSource> Intersect<TSource, TThat, TKey>(
            this IEnumerable<TSource> first,
            IEnumerable<TThat> second,
            Func<TSource, TKey> firstKey,
            Func<TThat, TKey> secondKey)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");

            var set = new HashSet<TKey>();
            foreach (var element in second)
            {
                set.Add(secondKey(element));
            }

            foreach (var element in first)
            {
                if (!set.Add(firstKey(element)))
                {
                    set.Remove(firstKey(element));
                    yield return element;
                }
            }
        }
    }
}