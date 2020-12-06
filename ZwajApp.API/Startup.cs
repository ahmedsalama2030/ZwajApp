using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ZwajApp.API.Data;
using ZwajApp.API.Helper;
using ZwajApp.API.Models;

namespace ZwajApp.API
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
            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            IdentityBuilder builder=  services. AddIdentityCore<User>
            (Opt=>{Opt.Password.RequireDigit=false;
            Opt.Password.RequiredLength=4;
            Opt.Password.RequireNonAlphanumeric=false;
            Opt.Password.RequireUppercase=false;
            }) ;

            builder=new IdentityBuilder(builder.UserType,typeof(Role),builder.Services);
            builder.AddEntityFrameworkStores<DataContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
             builder.AddSignInManager<SignInManager<User>>(); 
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
              services.AddAuthorization(
              options =>{
                  options.AddPolicy("RequireAdminRole",policy=>policy.RequireRole("Admin"));
                  options.AddPolicy("RequireModrole",policy=>policy.RequireRole("Admin","Moderator"));
                  options.AddPolicy("Viponly",policy=>policy.RequireRole("VIP"));
              }
              );


            services.AddMvc(options=>{
                var policy=new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddCors();
             services.AddAutoMapper();
            
           // Mapper.Reset();
            services.AddTransient<TrialData>();
           // services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IZwajRepository, ZwajRepository>();
            

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TrialData trialData)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(BuilderExtensions =>
                {
                    BuilderExtensions.Run(async con =>
                    {
                        con.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var error = con.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {

                            con.Response.AddApplicationError(error.Error.Message);
                            await con.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });

                //app.UseHsts();
            }
            // trialData.TrialUsers();
            app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
