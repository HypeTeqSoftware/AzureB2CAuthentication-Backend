using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using LearnSmartCoding.EssentialProducts.API.AuthorizationPolicies;

namespace MSAuth
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddMicrosoftIdentityWebApi(options =>
               {
                   Configuration.Bind("AzureAdB2C", options);

                   options.TokenValidationParameters.NameClaimType = "name";
               },
            options => { Configuration.Bind("AzureAdB2C", options); });


            services.AddCors(options =>
            {
                options.AddPolicy("AllRequests", builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(
                        origin => origin == "http://localhost:4200")
                    .AllowCredentials();
                });
            });

            services.AddAuthorization(options =>
            {
                // Create policy to check for the scope 'read'
                options.AddPolicy("UserAccess",
                    policy => policy.Requirements.Add(
                        new ScopesRequirement(
                            "my_scope")) //replace with your scope here
                    );

               
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins(

                    "http://localhost:4200"
                    )
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .AllowAnyHeader().AllowAnyMethod().AllowCredentials();

            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
