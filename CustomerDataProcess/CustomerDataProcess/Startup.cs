using Application.BusinessToBusiness.Commands;
using Application.BusinessToBusiness.Queries;
using Application.BusinessToCustomers.Commands;
using Application.BusinessToCustomers.Queries;
using Application.CustomerData.Commands;
using Application.CustomerData.Queries;
using Application.DataUpload.Commands.SaveDataUpload;
using Application.DataUpload.Queries.GetUpLoadDataType;
using Application.NumberLookup.Command;
using Application.NumberLookup.Query;
using Application.UserAccount.Queries;
using CustomerDataProcess.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistance;

namespace CustomerDataProcess
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var dbConnection = Configuration["CustomerData:DataSource"];
            //Configuration.GetConnectionString("DefaultConnection")
            services.AddDbContext<CustomerDataManagementContext>(options =>
                    options.UseSqlServer(dbConnection));

            var tt = Configuration["CustomerDataProcessingSetting"];
            services.Configure<CustomerDataProcessingSetting>(Configuration.GetSection("CustomerDataProcessingSetting"));


            services.AddScoped<IUserValidation, UserValidation>();
            services.AddScoped<IGetUpLoadDataTypeList, GetUpLoadDataTypeList>();
            services.AddScoped<ISaveUploadDataCommand, SaveUploadDataCommand>();
            services.AddScoped<IFileToDataModel, FileToDataModel>();
            services.AddScoped<ISaveCustomerData, SaveCustomerData>();
            services.AddScoped<IGetCustomerData, GetCustomerData>();
            services.AddScoped<IGetBusinessToCustomer, GetBusinessToCustomer>();
            services.AddScoped<IGetBusinessToBusiness, GetBusinessToBusiness>();
            services.AddScoped<IBusinessToBusinessFileToDataModel, BusinessToBusinessFileToDataModel>();
            services.AddScoped<IBusinessToCustomerFileToDataModel, BusinessToCustomerFileToDataModel>();
            services.AddScoped<ISaveBusinessToBusiness, SaveBusinessToBusiness>();
            services.AddScoped<IValidateEntiry, ValidatePhone>();
            services.AddScoped<IValidateBusinessCategoruEntiry, ValidateBusinessCategory>();
            services.AddScoped<ISaveBusinessToCustomer, SaveBusinessToCustomer>();

            services.AddScoped<IGetBusinessToCustomerArea, GetBusinessToCustomerArea>();
            services.AddScoped<IGetBusinessToCustomerState, GetBusinessToCustomerState>();
            services.AddScoped<IGetBusinessToCustomerCity, GetBusinessToCustomerCity>();
            services.AddScoped<IGetBusinessToCustomerCountry, GetBusinessToCustomerCountry>();
            services.AddScoped<IGetBusinessToCustomerDistinctName, GetBusinessToCustomerDestination>();

            services.AddScoped<IGetBusinessCities, GetBusinessCities>();
            services.AddScoped<IGetBusinessCountry, GetBusinessCountry>();
            services.AddScoped<IGetBusinessArea, GetBusinessArea>();
            services.AddScoped<IGetBusinessStates, GetBusinessStates>();
            services.AddScoped<IGetBusinessDestination, GetBusinessDestination>();
            services.AddScoped<IGetCustomerCities, GetCustomerCities>();
            services.AddScoped<IGetFullFilePath, GetFullFilePath>();
            services.AddScoped<IGetFileName, GetFileName>();
            services.AddScoped<IGetFileContent, GetFileContent>();
            services.AddScoped<ILoopupProcess, LoopupProcess>();
            services.AddScoped<IReadNumberLookup, ReadNumberLookup>();
            services.AddScoped<IGetNumberLoopUpData, GetNumberLoopUpData>();
            services.AddScoped<ISaveNumberLookUp, SaveNumberLookUp>();
            services.AddScoped<IGetCustomerPhone, GetCustomerPhone>();
            services.AddScoped<IGetBusinessToCustomerPhone, GetBusinessToCustomerPhone>();
            services.AddScoped<IGetBusinesstoBusinessPhone, GetBusinesstoBusinessPhone>();
            services.AddScoped<IGetCustomerDataQuality, GetCustomerDataQuality>();
            services.AddScoped<IGetCustomerTags, GetCustomerTags>();
            services.AddScoped<IGetCustomerNetwork, GetCustomerNetwork>();
            services.AddScoped<IGetCustomerBusinessVertical, GetCustomerBusinessVertical>();
            services.AddScoped<IGetCustomerDataDashBoard, GetCustomerDataDashBoard>();
            services.AddScoped<IExportCustomerDataByExcel, ExportCustomerDataByExcel>();
            services.AddScoped<IGetCustomerClientNames, GetCustomerClientNames>();
            services.AddScoped<IFilterCustomerTags, FilterCustomerTags>();
            services.AddScoped<IGetStates, GetStates>();
            services.AddScoped<IGetCustomerCountry, GetCustomerCountry>();
            services.AddScoped<IGetBusinessToCustomerSalary, GetBusinessToCustomerSalary>();
            services.AddScoped<IGetBusinessToCustomerAge, GetBusinessToCustomerAge>();
            services.AddScoped<IGetBusinessToCustomerRoles, GetBusinessToCustomerRoles>();
            services.AddScoped<IGetBusinessToCustomerExperience, GetBusinessToCustomerExperience>();
            services.AddScoped<IGetBusinessToCustomerTags, GetBusinessToCustomerTags>();
            services.AddScoped<IFilterBusinessToCustomer, FilterBusinessToCustomer>();
            services.AddScoped<IFilterBusinessToCustomerTags, FilterBusinessToCustomerTags>();
            services.AddScoped<IPrepareB2CDashBoard, PrepareB2CDashBoard>();
            services.AddScoped<IExportBusinessToCustomerFilter, ExportBusinessToCustomerFilter>();
            services.AddScoped<IGetBusinessCategory, GetBusinessCategory>();
            services.AddScoped<IGetBusinessToBusinessTags, GetBusinessToBusinessTags>();
            services.AddScoped<IFilterBusinessToBusinessTags, FilterBusinessToBusinessTags>();
            services.AddScoped<IFilterBusinessToBusiness, FilterBusinessToBusiness>();
            services.AddScoped<IPrepareB2BDashBoard, PrepareB2BDashBoard>();
            services.AddScoped<IBusinessToBusinessExport, BusinessToBusinessExport>();
            services.AddScoped<IGetNewRequestId, GetNewRequestId>();
            services.AddScoped<ISaveBusinessToBusinessTags, SaveBusinessToBusinessTags>();
            services.AddScoped<ISaveBusinessToCustomerTags, SaveBusinessToCustomerTags>();
            services.AddScoped<ISaveCustomerDataTags, SaveCustomerDataTags>();
            services.AddScoped<IGetLastCustomerDataRequestId, GetCustomerDataRequestId>();
            services.AddScoped<IGetLastCustomerRequestId, GetCustomerRequestId>();
            services.AddScoped<IGetLastBusinessRequestId, GetBusinessRequestId>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseExceptionHandler("/Home/Error");
            var loggerFile = Configuration["Logging:Log"];

            loggerFactory.AddFile(loggerFile);

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Index}/{id?}");
            });
        }
    }
}
