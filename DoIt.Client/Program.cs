using Blazored.LocalStorage;
using Blazored.SessionStorage;
using DoIt.Client.Services.Goals;
using DoIt.Client.Services.Ideas;
using DoIt.Client.Services.Modals;
using DoIt.Client.Services.Todos;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
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
            }
            else
            {
                AddImplementedServices(builder);
            }



            await builder.Build().RunAsync();
        }

        private static void AddCoreServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Authentication:Google", options.ProviderOptions);
            });

            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddBlazoredLocalStorage();

            // Custom Modal
            //builder.Services.AddSingleton<CascadingModal>();
            builder.Services.AddSingleton<ModalService>();
        }

        private static void AddImplementedServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:1001") });
            builder.Services.AddScoped(typeof(ITodoService), typeof(TodoService));
            builder.Services.AddScoped(typeof(IGoalService), typeof(GoalService));
            builder.Services.AddScoped(typeof(IIdeaService), typeof(IdeaService));
        }

        private static void AddMockingServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped(typeof(ITodoService), typeof(TodoServiceMock));
            builder.Services.AddScoped(typeof(IGoalService), typeof(GoalServiceMock));
            builder.Services.AddScoped(typeof(IIdeaService), typeof(IdeaServiceMock));
        }
    }
}
