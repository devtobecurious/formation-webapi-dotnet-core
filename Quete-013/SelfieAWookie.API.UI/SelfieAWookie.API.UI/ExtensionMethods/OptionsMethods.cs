using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SelfieAWookies.Core.Selfies.Infrastructures.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfieAWookie.API.UI.ExtensionMethods
{
    /// <summary>
    /// Custom options form config (json)
    /// </summary>
    public static class OptionsMethods
    {
        #region Public methods
        /// <summary>
        /// Add custom options form config (json)
        /// </summary>
        /// <param name="services"></param>
        public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SecurityOption>(configuration.GetSection("Jwt"));
        }
        #endregion
    }
}
