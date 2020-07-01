using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.BrandCommands;
using Application.Commands.CustomerCommands;
using Application.Commands.ExtraAddonsCommands;
using Application.Commands.LocationCommands;
using Application.Commands.RentCommands;
using Application.Commands.RoleCommands;
using Application.Commands.StatusCommands;
using Application.Commands.UserCommands;
using Application.Commands.VehicleCommands;
using Application.Commands.VehicleTypeCommands;
using AutoMapper;
using Implementation.CustomerCommands;
using Implementation.RentCommands;
using Implementation.StatusCommands;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RentApp.Helpers.MapperProfiles;
using RentApp.Helpers.Validators;
using Implementation.RoleCommands;
using Implementation.UserCommands;
using Implementation.VehicleCommands;
using Implementation.ExtraAddonsCommands;
using Implementation.BrandCommands;
using Implementation.ExtraAddonCommands;
using Implementation.VehicleTypeCommands;
using Implementation.LocationCommands;
using Domain;
using API.Helpers;
using Microsoft.AspNetCore.Http;
using Application;
using Newtonsoft.Json;
using API.Email;
using Application.Interfaces;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using Application.Commands.LogCommands;
using Implementation.LogCommands;

namespace RentApp
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
            //services.AddControllers();
            services.AddDbContext<AIContext>();
            services.AddTransient<IGetRoleCommand, EFGetRolesCommand>();
            services.AddTransient<IGetSingleRoleCommand, EFGetSingleRoleCommand>();
            services.AddTransient<IInsertRoleCommand, EFInsertRoleCommand>();
            services.AddTransient<IUpdateRoleCommand, EFUpdateRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EFDeleteRoleCommand>();
            //dependency injection for users
            services.AddTransient<IGetUsersCommand, EFGetUsersCommand>();
            services.AddTransient<IGetSingleUserCommand, EFGetSingleUserCommand>();
            services.AddTransient<IInsertUserCommand, EFInsertUserCommand>();
            services.AddTransient<IUpdateUserCommand, EFUpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EFDeleteUserCommand>();
            //dependency injection for vehicles
            services.AddTransient<IInsertVehicleCommand, EFInsertVehicleCommand>();
            services.AddTransient<IGetVehiclesCommand, EFGetVehiclesCommand>();
            services.AddTransient<IGetSIngleVehicleCommand, EFGetSingleVehicleCommand>();
            services.AddTransient<IDeleteVehicleCommand, EFDeleteVehicleCommand>();
            services.AddTransient<IUpdateVehicleCommand, EFUpdateVehicleCommand>();
            //dependency injection for extra addons
            services.AddTransient<IGetExtraAddonsCommand, EFGetExtraAddonsCommand>();
            services.AddTransient<IInsertExtraAddonCommand, EFInsertExtraAddonCommand>();
            services.AddTransient<IGetSingleExtraAddonCommand, EFGetSingleExtraAddonCommand>();
            services.AddTransient<IUpdateExtraAddonCommand, EFUpdateExtraAddonCommand>();
            services.AddTransient<IDeleteExtraAddonCommand, EFDeleteExtraAddonCommand>();
            //dependency injection for brands
            services.AddTransient<IGetBrandsCommand, EFGetBrandsCommand>();
            services.AddTransient<IInsertBrandCommand, EFInsertBrandCommand>();
            services.AddTransient<IGetSingleBrandCommand, EFGetSingleBrandCommand>();
            services.AddTransient<IDeleteBrandCommand, EFDeleteBrandCommand>();
            services.AddTransient<IUpdateBrandCommand, EFUpdateBrandCommand>();
            //dependency injection for vehicle types
            services.AddTransient<IGetVehicleTypesCommand, EFGetVehicleTypesCommand>();
            services.AddTransient<IGetSIngleVehicleTypeCommand, EFGetSIngleVehicleTypeCommand>();
            services.AddTransient<IInsertVehicleTypeCommand, EFInsertVehicleTypeCommand>();
            services.AddTransient<IDeleteVehicleTypeCommand, EFDeleteVehicleTypeCommand>();
            services.AddTransient<IUpdateVehicleTypeCommand, EFUpdateVehicleTypeCommand>();
            //dependency injection for location
            services.AddTransient<IGetLocationsCommand, EFGetLocationsCommand>();
            services.AddTransient<IGetSingleLocationCommand, EFGetSIngleLocationCommand>();
            services.AddTransient<IInsertLocationCommand, EFInsertLocationCommand>();
            services.AddTransient<IDeleteLocationCommand, EFDeleteTransmissionCommand>();
            services.AddTransient<IUpdateLocationCommand, EFUpdateLocationCommand>();
            //dependency injection for rents
            services.AddTransient<IGetRentsCommand, EFGetRentsCommand>();
            services.AddTransient<IGetSIngleRentCommand, EFGetSingleRentCommand>();
            services.AddTransient<IInsertRentCommand, EFInsertRentCommand>();
            services.AddTransient<IDeleteRentCommand, EFDeleteRentCommand>();
            services.AddTransient<IUpdateRentCommand, EFUpdateRentCommand>();
            services.AddTransient<IStartRentCommand, EFStartRentCommand>();
            services.AddTransient<IFinishRentCommand, EFFinishRentCommand>();
            //dependency injection for statuses
            services.AddTransient<IGetStatusesCommand, EFGetStatusesCommand>();
            services.AddTransient<IGetSingleStatusCommand, EFGetSingleStatusCommand>();
            services.AddTransient<IInsertStatusCommand, EFInsertStatusCommand>();
            services.AddTransient<IDeleteStatusCommand, EFDeleteStatusCommand>();
            services.AddTransient<IUpdateStatusCommand, EFUpdateStatusCommand>();
            //dependency injection for customers
            services.AddTransient<IGetCustomersCommand, EFGetCustomersCommand>();
            services.AddTransient<IGetSingleCustomerCommand, EFGetSingleCustomerCommand>();
            services.AddTransient<IInsertCustomerCommand, EFInsertCustomerCommand>();
            services.AddTransient<IUpdateCustomerCommand, EFUpdateCustomerCommand>();
            services.AddTransient<IDeleteCustomerCommand, EFDeleteCustomerCommand>();
            //dependency for logs
            services.AddTransient<IGetLogsCommand, EFGetLogsCommand>();
            //dependency for email
            var section = Configuration.GetSection("Email");
            var sender = new SmtpEmailSender(section["host"], Int32.Parse(section["port"]), section["from"], section["password"]);
            services.AddSingleton<IEmailSender>(sender);
            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new BrandProfile());
            //});
            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);
            //Swagger
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "AI Rent a Car API", version = "V1" });
            //});
            //Swagger
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews()
                .AddNewtonsoftJson()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<VehicleValidator>());
            services.AddTransient<IGetLoggedUser, EFGetLoggedUserCommand>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            var key = Configuration.GetSection("Encryption")["key"];

            var enc = new Encryption(key);
            services.AddSingleton(enc);


            services.AddTransient(s =>
            {
                var http = s.GetRequiredService<IHttpContextAccessor>();
                var value = http.HttpContext.Request.Headers["Authorization"].ToString();
                var encryption = s.GetRequiredService<Encryption>();

                try
                {
                    var decodedString = encryption.DecryptString(value);
                    decodedString = decodedString.Substring(0, decodedString.LastIndexOf("}") + 1);
                    var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);
                    user.IsLogged = true;
                    return user;
                }
                catch (Exception e)
                {
                    return new LoggedUser
                    {
                        IsLogged = false
                    };
                }
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
