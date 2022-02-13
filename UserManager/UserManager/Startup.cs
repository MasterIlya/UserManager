using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManager.Configuration;
using UserManager.Filters;

namespace UserManager
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(AuthenticateFilter));
            });

            services.AddHttpContextAccessor();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Users/Authentication");
                    options.ExpireTimeSpan = new System.TimeSpan(1, 0, 0, 0);
                }); ;
            services.AddAuthorization();
            services.AddControllersWithViews();

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var appSettings = new ApplicationSettings();
            appSettings.Init(builder);

            new DependencyInjection(appSettings, services).Init();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Users}/{action=Authentication}/{id?}");
            });
        }
    }
}
