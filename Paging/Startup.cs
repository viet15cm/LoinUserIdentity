﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Paging.DbContextLayer;
using Paging.Models;
using Paging.Services;
using Paging.Services.MailService;
using Paging.Services.NavbarServices;
using Paging.Services.ServicesIdentityError;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging
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

            services.Configure<List<NavbarItemSettings>>(Configuration.GetSection("NavBarItemSettings"));
            services.AddSingleton<IShowItems, ShowItems>();
            services.Configure<MailSetting>(Configuration.GetSection("MailSetting"));
            services.AddSingleton<UserAlbumServices>();
            services.AddSingleton<ISendMailService, SendMailService>();
            services.AddSingleton<ProductServices>();
            services.AddSingleton<ItemServices>();
            services.AddSingleton<UserDbContext>();
            services.AddIdentity<AppUser, IdentityRole>()
               .AddEntityFrameworkStores<UserDbContext>()
               .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options => {

                //Thiết lập về Password
                options.Password.RequireDigit = false; // Không bắt phải có số
                options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = false; // Không bắt buộc chữ in
                options.Password.RequiredLength = 8; // Số ký tự tối thiểu của password
                options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

                // Cấu hình Lockout - khóa user
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
                options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
                options.Lockout.AllowedForNewUsers = true;

                // Cấu hình về User.
                options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

                options.User.RequireUniqueEmail = true;  // Email là duy nhất

                //Cấu hình đăng nhập.
                options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại
                options.SignIn.RequireConfirmedAccount = true;

            });
            // Thiết lập , nếu IsPersistent = true thì đăng nhập user sẽ duy trì trong 1 ngày ,  IsPersistent = fasle thì đăng nhập user sẽ duy trì mãi mãi , với cookie máy khách 
            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
            });
            // Cấu hình ajax that
            //services.AddControllers().AddJsonOptions(options => {
            //    options.JsonSerializerOptions.PropertyNamingPolicy = null;
            //    options.JsonSerializerOptions.DictionaryKeyPolicy = null;

            //});
            //services.AddMvc();
            //services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddSingleton<IdentityErrorDescriber, AppIdentityErrorDescriber>();
            services.AddRazorPages();
            
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
