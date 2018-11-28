using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            //WebHost.CreateDefaultBuilder(args)
            //    .UseStartup<Startup>();


        WebHost.CreateDefaultBuilder(args)//使用默认的配置信息来初始化一个新的IWebHostBuilder实例
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
            var env = hostingContext.HostingEnvironment;

            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                  .AddJsonFile("Content.json", optional: false, reloadOnChange: false)
                  .AddEnvironmentVariables();

        })
            .UseStartup<Startup>();// 为Web Host指定了Startup类
    }
}
