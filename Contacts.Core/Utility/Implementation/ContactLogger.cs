using Contacts.Common.Core.Utility.Api;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Contacts.Common.Core.Utility.Implementation
{
    public class ContactLogger: IContactLogger
    {
        #region Declarations
        private readonly ILogger _logger =
            LoggerManager.GetLogger(Assembly.GetCallingAssembly(), "ContactLogger");
        #endregion Declarations
        #region IRteLogger Implementations
        /// <summary>
        /// Stores debug logs
        /// </summary>
        /// <param name="message">Message</param>
        public void Debug(string message)
        {
            _logger.Log(typeof(ContactLogger), Level.Debug, message, null);
        }

        /// <summary>
        /// Stores error logs
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="exception">Error details</param>
        public void Error(string message, Exception exception)
        {
            _logger.Log(typeof(ContactLogger), Level.Error, message, exception);
        }

        /// <summary>
        /// Stores information logs
        /// </summary>
        /// <param name="message">Message</param>
        public void Info(string message)
        {
            _logger.Log(typeof(ContactLogger), Level.Info, message, null);
        }
        #endregion IRteLogger Implementations
    }
}
