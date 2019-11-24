using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Common.Core.Utility.Interface
{
    public interface IContactLogger
    {
        #region Logger Method Declarations
        /// <summary>
        /// Stores information logs
        /// </summary>
        /// <param name="message">Message</param>
        void Info(string message);

        /// <summary>
        /// Stores error logs
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="exception">Error details</param>
        void Error(string message, Exception exception);

        /// <summary>
        /// Stores debug logs
        /// </summary>
        /// <param name="message">Message</param>
        void Debug(string message);
        #endregion Logger Method Declarations
    }
}
