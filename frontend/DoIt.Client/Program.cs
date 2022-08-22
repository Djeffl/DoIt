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

using DoIt.Client.Services.IdeaCategories;
using DoIt.Client.Settings;

namespace DoIt.Client
{
	public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var configuration = builder.Configuration;
            builder.RootComponents.Add<App>("#app");

            AddCoreServices(builder);

            Console.WriteLine(configuration.GetValue<bool>("MockApplication"));
            if (configuration.GetValue<bool>("MockApplication"))
            {
                AddMockingServices(builder);
            }
            else
            {
                AddImplementedServices(builder, configuration);
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

            // Icons
            //builder.Services.AddSingleton<IconService>();

            // Custom Modal
            builder.Services.AddSingleton<ModalService>();
        }

        private static void AddImplementedServices(WebAssemblyHostBuilder builder, IConfiguration configuration)
        {
            var apiSettings = configuration.GetSection(ApiSettings.ApiKey).Get<ApiSettings>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiSettings.Url) });
            builder.Services.AddScoped(typeof(ITodoService), typeof(TodoService));
            builder.Services.AddScoped(typeof(IGoalService), typeof(GoalService));
            builder.Services.AddScoped(typeof(IIdeaService), typeof(IdeaService));
            builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
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
