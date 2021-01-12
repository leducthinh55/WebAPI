using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Infrastructure.Data;
using Infrastructure.Infrastructure;
using Infrastructure.Respositories;
using Service;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebAPI
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

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<StoreContext>();
            #region DI
            // add for data
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IProductRespository, ProductRespository>();
            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<IProductTypeRespository, ProductTypeRespository>();
            services.AddTransient<IProductTypeService, ProductTypeService>();

            services.AddTransient<ITypeGroupRespository, TypeGroupRespository>();
            services.AddTransient<ITypeGroupService, TypeGroupService>();

            services.AddTransient<ITypeGroupUserRespository, TypeGroupUserRespository>();
            services.AddTransient<ITypeGroupUserService, TypeGroupUserService>();

            services.AddTransient<IColorRespository, ColorRespository>();
            services.AddTransient<IColorService, ColorService>();

            services.AddTransient<IProductDetailRespository, ProductDetailRespository>();
            services.AddTransient<IProductDetailService, ProductDetailService>();

            services.AddTransient<IModifiedProductRespository, ModifiedProductRespository>();
            services.AddTransient<IModifiedProductService, ModifiedProductService>();

            services.AddScoped<IUserClaimsPrincipalFactory<User>, UserClaimsPrincipalFactory<User, IdentityRole>>();

            #endregion

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 

            services.AddIdentityCore<User>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequiredLength = 4;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
            }).AddRoles<IdentityRole>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<StoreContext>()
                .AddDefaultTokenProviders();

            String securityKey = "qwertyuioasdfghjkwertyui1235";
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(option =>
                {
                    option.RequireHttpsMetadata = false;
                    option.SaveToken = true;
                    option.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey)),
                        ValidAudience = securityKey,
                        ValidIssuer = "thinh",
                    };
                });

            services.AddMvc().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();

            app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI kk");
           });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



        }
    }
}
