//resource: http://scottdorman.github.io/2016/03/17/integrating-asp.net-core-dependency-injection-in-mvc-4/

using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Mvc;

namespace Apadana.Web.App_Structure
{
    public class DefaultDependencyResolver : IDependencyResolver
    {
        protected IServiceProvider serviceProvider;

        public DefaultDependencyResolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public object GetService(Type serviceType)
        {
            return this.serviceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.serviceProvider.GetServices(serviceType);
        }
    }


}