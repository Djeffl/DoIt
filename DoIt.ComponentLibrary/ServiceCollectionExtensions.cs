using DoIt.ComponentLibrary.Modal;
using Microsoft.Extensions.DependencyInjection;

namespace DoIt.ComponentLibrary
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddModal(this IServiceCollection services)
		{
			return services.AddScoped<ModalService>();
		}
	}
}
