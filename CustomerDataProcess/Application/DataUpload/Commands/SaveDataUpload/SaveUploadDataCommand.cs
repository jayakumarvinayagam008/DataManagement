using Application.BusinessToBusiness.Queries;
using Application.BusinessToCustomers.Queries;
using Application.Common;
using Application.CustomerData.Queries;
using Application.DataUpload.Queries.GetUpLoadDataType;
using Application.UploadSummary.Command;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;
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
        private IUploadProcess[] uploadProcesses = new IUploadProcess[] {
            new BusinessToCustomerUploadProcess()
        };
        private readonly IGetNewRequestId _getNewRequestId;
        private readonly ISaveBusinessToBusinessTags _saveBusinessToBusinessTags;
        private readonly ISaveBusinessToCustomerTags _saveBusinessToCustomerTags;
        private readonly ISaveCustomerDataTags _saveCustomerDataTags;
        private readonly ISaveUploadSummary _saveUploadSummary;
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
            ISaveCustomerDataTags saveCustomerDataTags,
            ISaveUploadSummary saveUploadSummary)
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
            _saveUploadSummary = saveUploadSummary;
        }

        public UploadSaveStatus Upload(SaveDataModel saveDataModel)
        {
            var requestId = _getNewRequestId.Get(saveDataModel.UploadTypeId);
            var tags = !string.IsNullOrWhiteSpace(saveDataModel.Tags) ?
                SplitSting.Split(saveDataModel.Tags, ',') : new string[] { };

            var uploadStatus = new UploadSaveStatus();
            if (saveDataModel.UploadTypeId == (int)CustomerDataUploadType.BusinessToBusiness)
            {
                var businessToBusinessData = _businessToBusinessFileToDataModel.ReadFileData(saveDataModel);
                // remove dublicate
                var businessToBusiness = businessToBusinessData.Item1.DistinctBy(x => x.PhoneNew);
                uploadStatus.TotalRows = businessToBusinessData.Item2;

                // Check business category validation
                // Ceck phone number validation
                var numbers = _getBusinesstoBusinessPhone.Get();
                businessToBusiness = businessToBusiness.Except(numbers, x => x.PhoneNew, y => y).ToList();
                numbers = null;
                if (businessToBusiness.Count() > 0)
                {
                    // validate Business category
                    var validBusinessToBusiness = businessToBusiness;                       
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
            else if (saveDataModel.UploadTypeId == (int)CustomerDataUploadType.BusinessToCustomer)
            {
                var businessToCustomer = _businessToCustomerFileToDataModel.ReadFileData(saveDataModel);
                var businessToCustomerData = businessToCustomer.Item1.DistinctBy(x => x.MobileNew);
                uploadStatus.TotalRows = businessToCustomer.Item2;

                var dbNumbers = _getBusinessToCustomerPhone.Get();
                var filteredData = businessToCustomerData.Except(dbNumbers, x => x.MobileNew, y => y).ToList();
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
            else if (saveDataModel.UploadTypeId == (int)CustomerDataUploadType.CustomerData)
            {
                var customerData = _CustomerDataFileToDataModel.ReadFileData(saveDataModel);
                var customerUploadedData = customerData.Item1.DistinctBy(x => x.Numbers);
                uploadStatus.TotalRows = customerData.Item2;

                // Mobile number filter
                var dbNumbers = _getCustomerPhone.Get();
                var filteredData = customerUploadedData.Except(dbNumbers, x => x.Numbers, y => y).ToList();
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

            if(uploadStatus.IsUploaded)
            {
                var uploadSummary = new SaveSummaryModel
                {
                    ClientFileName = saveDataModel.ClientFileName,
                    UploadTypeId = saveDataModel.UploadTypeId,
                    TotalRows = uploadStatus.TotalRows,
                    UploadedRows = uploadStatus.UploadedRows,
                    Path = saveDataModel.FilePath,
                    ServerFileName = ServerFileName(saveDataModel.FilePath),
                    RequestId = requestId,
                    SaveStatus = uploadStatus.IsUploaded
                };
                _saveUploadSummary.Save(uploadSummary);
            }
            

            return uploadStatus;
        }
        private string ServerFileName(string path)
        {
            return Path.GetFileName(path);
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