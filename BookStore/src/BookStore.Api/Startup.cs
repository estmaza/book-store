using AutoMapper;
using BookStore.Api.Infrastructure;
using BookStore.BL;
using BookStore.BL.Infrastructure;
using BookStore.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BookStore.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();

            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new AutoMapperProfileConfiguration());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContextPool<ApplicationContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PostgreSqlConnection")));

            // Add framework services.
            services.AddMvcCore().AddJsonFormatters();
            services.AddCors();

            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookService, BookService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ApplicationContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseResponseCompression();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseMvc();

            DbInitializer.Initialize(context);
        }
    }
}
