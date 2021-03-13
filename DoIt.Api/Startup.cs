using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoIt.Api.Data;
using DoIt.Api.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace DoIt.Api
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAuthentication(OptionsBuilderConfigurationExtensions =>
			{
				OptionsBuilderConfigurationExtensions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			}).AddCookie()
			.AddGoogle(googleOptions =>
			{
				googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
				googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
			});

			services.AddMvc();

			services.AddControllers();

			services.AddSwaggerGen();

			services.AddDbContext<DoItContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DoItContext")));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseCors(policy =>
				policy.WithOrigins("http://localhost:5000", "https://localhost:5001")
				.AllowAnyMethod()
				.WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization)
				.AllowCredentials());

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

			app.UseSwaggerEndpoint();
		}
	}
}
