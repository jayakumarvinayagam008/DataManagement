using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.BusinessToBusiness.Queries;
using Application.BusinessToCustomers.Queries;
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

            services.AddScoped<IGetArea, GetArea>();
            services.AddScoped<IGetState, GetState>();
            services.AddScoped<IGetCity, GetCity>();
            services.AddScoped<IGetCountry, GetCountry>();
            services.AddScoped<IGetDistinctName, GetDestination>();

            services.AddScoped<IGetBusinessCities, GetBusinessCities>();
            services.AddScoped<IGetBusinessCountry, GetBusinessCountry>();
            services.AddScoped<IGetBusinessArea, GetBusinessArea>();
            services.AddScoped<IGetBusinessStates, GetBusinessStates>();
            services.AddScoped<IGetBusinessDestination, GetBusinessDestination>();
            services.AddScoped < IGetCustomerCities, GetCustomerCities>();
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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
