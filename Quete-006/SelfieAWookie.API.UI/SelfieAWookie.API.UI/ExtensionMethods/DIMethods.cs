using Microsoft.Extensions.DependencyInjection;
using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfieAWookie.API.UI.ExtensionMethods
{
    public static class DIMethods
    {
        #region Public methods
        /// <summary>
        /// Prepare customs dependency injections
        /// </summary>
        /// <param name="services"></param>
        public static void AddInjections(this IServiceCollection services)
        {
            services.AddScoped<ISelfieRepository, DefaultSelfieRepository>();
        }
        #endregion
    }
}
