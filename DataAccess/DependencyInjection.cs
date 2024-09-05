using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DependencyInjection
    {
        public static void AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IBookRepository,BookRepository>();
        }
    }
}
