using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService,BookService>();
        }
    }
}
