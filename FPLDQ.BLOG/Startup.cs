using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace FPLDQ.BLOG
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
            services.AddControllers();


            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version ="v1.1.1.0",
                    Title="BLOG webapi",
                    Description ="this is a blog project",
                    TermsOfService=null,
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name="FPLDQ",Email="791085869@qq.com"}
                });
                //添加读取注释服务
                var basePath = System.IO.Directory.GetCurrentDirectory();
                var xmlPath = System.IO.Path.Combine(basePath, "bin/Debug/netcoreapp3.0/apihelper.xml");
                c.IncludeXmlComments(xmlPath,true);

               
                // OpenApiSecurityRequirement security =
                //new  OpenApiSecurityRequirement().Add( 
                //    new OpenApiSecurityScheme { Name="Bearer", In=ParameterLocation.Header}
                //    ,new List<string>().Add(""));
                
                //c.AddSecurityRequirement(security);//添加一个必须的全局安全信息，和AddSecurityDefinition方法指定的方案名称要一致，这里是Bearer。
                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description = "JWT授权(数据将在请求头中进行传输) 参数结构: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",//jwt默认的参数名称
                //    In = "header",//jwt默认存放Authorization信息的位置(请求头中)
                //    Type = "apiKey"
                //});


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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "openapi");
            });
            #endregion

        }
    }
}
