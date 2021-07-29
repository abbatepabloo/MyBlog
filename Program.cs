using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyBlog.Classes;
using static System.Net.WebRequestMethods;
using System.Reflection.Metadata;
using System.Net.Http.Json;

namespace MyBlog
{
    public class Program
    {
        IConfiguration Configuration { get; }
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IInformationProvider, InformationProvider>();

            await builder.Build().RunAsync();
        }
    }
}
