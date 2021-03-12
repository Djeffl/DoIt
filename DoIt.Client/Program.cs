using DoIt.Client.Services;
using DoIt.Client.Services.Mocks;
using DoIt.ComponentLibrary;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DoIt.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            AddCoreServices(builder);

            if (builder.HostEnvironment.IsDevelopment())
            {
                AddMockingServices(builder);
            } else
            {
                AddImplementedServices(builder);
            }

            

            await builder.Build().RunAsync();
        }

        private static void AddCoreServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddModal();
        }

        private static void AddImplementedServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped(typeof(ITodoService), typeof(TodoService));
        }

        private static void AddMockingServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped(typeof(ITodoService), typeof(TodoServiceMock));
        }
    }
}
