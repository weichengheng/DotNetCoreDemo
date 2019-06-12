using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Ken.Tutorial.Web.Repositories;

namespace Ken.Tutorial.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //引入mvc模块
            services.AddMvc();

            //配置DbContext注入
            services.AddTransient<TestDbContext>();

            //配置Repository注入
            services.AddTransient<BillDetailSync2SapLogRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Hello World!");
            // });

            app.UseMvc(routes=>{
                //配置默认路由
                routes.MapRoute(
                    name:"Default",
                    template:"{controller}/{action}",
                    defaults:new {controller="Home",Action="Index"}
                );

                //配置ActionResult 测试专用路由
                routes.MapRoute(
                    name:"ActionResultTest",
                    template:"art/{action}",
                    defaults:new {controller="ActionResultTest" }
                );

                //配置 参数映射 测试专用路由
                routes.MapRoute(
                    name:"ParamsMappingTest",
                    template:"pmt/{action}/{id?}",
                    defaults:new {controller="ParamsMappingTest" }
                );
            });
        }
    }
}
