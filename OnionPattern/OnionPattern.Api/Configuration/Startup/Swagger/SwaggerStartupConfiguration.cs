using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace OnionPattern.Api.Configuration.Startup.Swagger
{
    /// <summary>
    /// Swagger Startup Configuration
    /// </summary>
    public static class SwaggerStartupConfiguration
    {
        /// <summary>
        ///     Setup configuration for Swagger
        /// </summary>
        /// <param name="services"></param>
        /// <param name="hostingEnvironment"></param>
        public static void ConfigureService(IServiceCollection services, IHostingEnvironment hostingEnvironment)
        {
            var path = Path.Combine(ApplicationEnvironment.ApplicationBasePath, "OnionPattern.Api.xml");

            services.AddSwaggerGen(options =>
            {
                // resolve the IApiVersionDescriptionProvider service
                // note: that we have to build a temporary service provider here because one has not been created yet
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                //add a swagger document for each discovered API version
                // note: you might choose to skip or document deprecated API versions differently
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                }

                // add a custom operation filter which sets default values
                options.OperationFilter<SwaggerDefaultValues>();

                options.IncludeXmlComments(path);
                options.DescribeAllEnumsAsStrings();
            });
        }

        /// <summary>
        /// Configure the Swagger Endpoints and Middleware
        /// </summary>
        /// <param name="application"></param>
        /// <param name="apiVersionDescriptionProvider"></param>
        public static void Configure(IApplicationBuilder application, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint
            application.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            application.UseSwaggerUI(config =>
            {
                // build a swagger endpoint for each discovered API version
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    config.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });
        }

        internal static Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info
            {
                Title = $"Onion Pattern (Architecture) API {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = "Onion Pattern Apis with Api-Versioning",
                Contact = new Contact { Name = "André Davis", Email = "davis.andre@gmail.com" },
                TermsOfService = "WTFPL",
                License = new License { Name = "WTFPL", Url = "https://github.com/CubicleJockey/OnionPattern/blob/Develop/LICENSE.md" }
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}
