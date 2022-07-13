using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Myket_Shop.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Myket_Shop.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Myket_Shop
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
            services.AddRazorPages();
            services.AddControllersWithViews();
            #region Db Context
            services.AddDbContext<MyketShopContext>(options => options.UseSqlServer("Data Source=.;Initial Catalog=Myket-Shop;Integrated Security=true"));
            #endregion
            #region IoC
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion
            #region Authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            {
                option.LoginPath = "/Account/Login";
                option.LogoutPath = "/Account/Logout";
                option.ExpireTimeSpan = TimeSpan.FromDays(5);
            });
            #endregion
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/Admin"))
                {
                    if (!context.User.Identity.IsAuthenticated)
                    {
                        context.Response.Redirect("/Account/Login");
                    }
                    if (!bool.Parse(context.User.FindFirstValue("IsAdmin")))
                    {
                        context.Response.Redirect("/Account/Login");
                    }
                }
                await next.Invoke();
            });
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
