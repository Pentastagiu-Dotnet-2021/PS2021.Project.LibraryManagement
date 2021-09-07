using Microsoft.Extensions.DependencyInjection;
using Project.LibraryManagement.API.Config;
using Project.LibraryManagement.Core.Interfaces;
using Project.LibraryManagement.Infrastructure.DataAccess;
using Project.LibraryManagement.Repositories;
using Project.LibraryManagement.Services;
using Project.LibraryManagement.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.LibraryManagement.API.Extensions
{
    public static class LibraryManagementDependencyInjectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IAppConfig>(ctx => AppConfig.Instance);
            services.AddSingleton<IDbConnectionFactory>(ctx =>
                new DbConnectionFactory(ctx.GetRequiredService<IAppConfig>().ConnectionString));

            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IBookService, BookService>();
            return services;
        }
    }
}
