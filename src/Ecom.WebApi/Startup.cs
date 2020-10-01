using Ecom.Commands;
using Ecom.DomainServices;
using Ecom.Framework;
using Ecom.Queries;
using Ecom.Repositories;
using Ecom.WebApi.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.WebApi
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
            RegisterServices(services);
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseHttpsRedirection();  

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}"
                );
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<CommandManager>();
            services.AddSingleton<QueryManager>();
            services.AddSingleton<IEcomConfigManager, EcomConfigManager>();

            services.AddSingleton(typeof(ICommandHandler<CheckoutCommand, CommandResponse>), typeof(CheckoutCommandHandler));
            services.AddSingleton(typeof(IQueryHandler<ProductSearchQuery, QueryResult>), typeof(ProductSearchQueryHandler));

            //Framework services
            services.AddSingleton<IEncrptor, Encryptor>();

            // Doamin Services
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IDiscountStratigyProvider, DiscountStratigyProvider>();
            services.AddSingleton<IMongoDbService, MongoDbService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IExternalUserService, GoogleUserService>();

            // Repositories
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ICheckoutRepository, CheckoutRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserRoleRepository, UserRoleRepository>();

            // Identity
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<ITokenService, JwtTokenService>();
            
            
            // Web Context
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IHttpContextProvider, HttpContextProvider>();
            services.AddHttpClient();
            

            ConfigureJwtServices(services);
        }

        private void ConfigureJwtServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = ApiConstants.JwtIssuer,
                       ValidAudience = ApiConstants.JwtAudence,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ApiConstants.JwtKey)),
                       ValidateLifetime = true,
                   };

                   options.Events = new JwtBearerEvents
                   {
                       OnAuthenticationFailed = context =>
                       {
                           if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                           {
                               context.Response.Headers.Add("Token-Expired", "true");
                           }
                           return Task.CompletedTask;
                       },
                       OnMessageReceived = context =>
                       {
                           return Task.CompletedTask;
                       },
                       OnTokenValidated = context =>
                       {
                           return Task.CompletedTask;
                       }
                   };
               });
        }

    } //end class  
}
