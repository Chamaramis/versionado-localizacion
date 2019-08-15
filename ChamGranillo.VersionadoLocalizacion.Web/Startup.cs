using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ChamGranillo.VersionadoLocalizacion.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning(
                options =>
                {
                    options.DefaultApiVersion = ApiVersion.Parse("1");
                    options.RegisterMiddleware = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ReportApiVersions = true;

                    //por tipo de media
                    //options.ApiVersionReader = new MediaTypeApiVersionReader("version");
                    //[header] Content-Type: application/json;version=x.x

                    //por query string
                    //options.ApiVersionReader = new QueryStringApiVersionReader("version");
                    //http://url.com/controller?version=x.x

                    //por segmento de URL
                    options.ApiVersionReader = new UrlSegmentApiVersionReader();
                    //[Route("[controller]/v{version:apiVersion}")]

                    //por header
                    //options.ApiVersionReader = new HeaderApiVersionReader("version");
                    //[header] version: x.x
                });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseApiVersioning();
            app.UseMvc();
        }
    }
}
