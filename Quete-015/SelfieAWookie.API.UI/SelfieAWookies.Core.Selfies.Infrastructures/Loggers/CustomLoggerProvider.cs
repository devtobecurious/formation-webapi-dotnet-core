using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.Core.Selfies.Infrastructures.Loggers
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        #region Fields
        private ConcurrentDictionary<string, CustomMessageLogger> _loggers = new ConcurrentDictionary<string, CustomMessageLogger>();
        #endregion

        #region Public methods
        public ILogger CreateLogger(string categoryName)
        {
            this._loggers.GetOrAdd(categoryName, key => new CustomMessageLogger());

            return this._loggers[categoryName];
        }

        public void Dispose()
        {
            this._loggers.Clear();
        }
        #endregion
    }
}
