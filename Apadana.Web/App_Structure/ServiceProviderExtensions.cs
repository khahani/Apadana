//resource: http://scottdorman.github.io/2016/03/17/integrating-asp.net-core-dependency-injection-in-mvc-4/

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Apadana.Web.App_Structure
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddControllersAsServices(this IServiceCollection services,
           IEnumerable<Type> controllerTypes)
        {
            foreach (var type in controllerTypes)
            {
                services.AddTransient(type);
            }

            return services;
        }
    }
}