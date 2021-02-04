using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Loan_management
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
            services.AddControllersWithViews();//MVC服务注册

            // 将 Session 存在 ASP.NET Core 内存中
            services.AddDistributedMemoryCache();

            services.AddSession();//配置session
            ///依赖注入
            ///1.注册服务（需要把依赖的所有服务全部注册）
            ///2.直接在控制器中通过构造函数注入
            ///IOC容器
            //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();//单例模式，整个应用程序生命周期以内只创建一个实例
            //services.Add(new ServiceDescriptor(typeof(IAtomService<>), typeof(AtomService<>), ServiceLifetime.Scoped));//泛型注入
            //services.AddScoped<ISecurityService, SecurityService>();//在同一个Scope内只初始化一个实例 ，可以理解为（ 每一个request级别只创建一个实例，同一个http request会在一个 scope内）
            //services.Transient<ISecurityService, SecurityService>();//每一次GetService都会创建一个新的实例
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

            // SessionMiddleware 加入 Pipeline
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Main}/{action=Index}/{id?}");
            });
        }
    }
}
