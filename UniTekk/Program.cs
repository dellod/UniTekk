using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using UniTekk.Models.Products;

namespace UniTekk
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Was testing out Nancy.Json
            /*
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Brand nike = new Brand("Nike", 1);
            Camera type1 = new Camera("test", 2, nike, 1.00, 50, 500, 500);
            Console.WriteLine(serializer.Serialize(type1));
            */
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
