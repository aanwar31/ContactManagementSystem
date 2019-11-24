using Contacts.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Data.Api.Services
{
    public interface IContactDataService
    {
        Task<bool> CreateContactDetails(Contact data);
        Task<IList<Contact>> GetAllContactsDetails();
        Task<Contact> GetContactByID(decimal id);
        //Task<bool> DeleteContact();
        //Task<Contact> UpdateContact();
        //Task<Contact> GetContactDetailsByID();
    }
}
