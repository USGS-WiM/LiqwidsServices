using Microsoft.EntityFrameworkCore;
using LiqwidsDB;
using WIM.Security.Authentication.Basic;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LiqwidsAgent;
using Microsoft.AspNetCore.Mvc;
using WIM.Services.Middleware;
using WIM.Services.Analytics;
using WIM.Utilities.ServiceAgent;
using WIM.Services.Resources;
using LiqwidsServices.Filters;

namespace LiqwidsServices
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
            if (env.IsDevelopment()) {
                //builder.AddUserSecrets<Startup>();
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            Configuration = builder.Build();
        }//end startup       

        public IConfigurationRoot Configuration { get; }

        //Method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //add functionality to inject IOptions<T>
            services.AddOptions();
            //Configure injectable obj
            services.Configure<APIConfigSettings>(Configuration.GetSection("APIConfigSettings"));
            // Add framework services
            //provides access to httpcontext
            services.AddHttpContextAccessor();
            services.AddScoped<ILiqwidsAgent, LiqwidsAgent.LiqwidsAgent>();
            services.AddScoped<IAnalyticsAgent, GoogleAnalyticsAgent>((gaa) => new GoogleAnalyticsAgent(Configuration["AnalyticsKey"]));

            services.AddDbContext<LiqwidsDBContext>(options =>
                                                        options.UseNpgsql(String.Format(Configuration
                                                            .GetConnectionString("dbConnection"), Configuration["dbuser"], Configuration["dbpassword"], Configuration["dbHost"]),
                                                            //default is 1000, if > maxbatch, then EF will group requests in maxbatch size
                                                            opt => { opt.MaxBatchSize(1000); })
                                                            .EnableSensitiveDataLogging());

            services.AddScoped<IBasicUserAgent, LiqwidsAgent.LiqwidsAgent>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = BasicDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = BasicDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = BasicDefaults.AuthenticationScheme;
            }).AddBasicAuthentication();
             services.AddAuthorization(options => loadAutorizationPolicies(options));



            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                                                                 .AllowAnyMethod()
                                                                 .AllowAnyHeader()
                                                                 .AllowCredentials());
            });

            services.AddMvc(options => 
            { options.RespectBrowserAcceptHeader = true;
                options.Filters.Add(new LiqwidsHypermedia());
                //for hypermedia
                options.Filters.Add(new LiqwidsHypermedia());
            })
                .AddJsonOptions(options => loadJsonOptions(options));                                
                                
        }     

        // Method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            app.UseCors("CorsPolicy");
            app.Use_Analytics();
            app.UseX_Messages();
            app.UseAuthentication();
            app.UseMvc();            
        }

#region Helper Methods
        private void loadJsonOptions(MvcJsonOptions options)
        {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            options.SerializerSettings.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
            options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            options.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.None;
            options.SerializerSettings.TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple;
            options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.None;
        }
        private void loadAutorizationPolicies(AuthorizationOptions options)
        {
            options.AddPolicy(
                "CanModify",
                policy => policy.RequireRole("Administrator", "Manager"));
            options.AddPolicy(
                "Restricted",
                policy => policy.RequireRole("Administrator", "Manager", "General"));
            options.AddPolicy(
                "AdminOnly",
                policy => policy.RequireRole("Administrator"));
        }

#endregion
    }
}
