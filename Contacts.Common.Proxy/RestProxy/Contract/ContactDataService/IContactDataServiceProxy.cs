using Contacts.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Common.Proxy.RestProxy.Contract.ContactsDataService
{
    public interface IContactDataServiceProxy: IApiProxy
    {
        #region Method Declarations
        Task<IList<Contact>> GetAllContactsDetails();
        Task<bool> CreateContactDetails(Contact contact);
        Task<Contact> GetDetails(decimal id);

        #endregion Method Declarations
    }
}
