using Contacts.Common.Proxy.HttpClient;
using Contacts.Common.Proxy.RestProxy.Contract.ContactsDataService;
using Contacts.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Contacts.Common.Proxy.RestProxy.Impl.ContactDataService
{
    public class ContactDataServiceProxy : IContactDataServiceProxy
    {
        private readonly Uri _baseAddress;
        private const string GetAllContactsDetailsUrl = "api/Contacts/GetAllContactsDetails";
        private const string CreateContactDetailsUrl = "api/Contacts/CreateContact";
        private const string GetDetailsUrl = "api/Contacts/GetContactByID/{0}";
        public ContactDataServiceProxy(string baseAddress)
        {
            _baseAddress = new Uri(baseAddress);
        }

        public async Task<IList<Contact>> GetAllContactsDetails()
        {
            using(var httpClient=new CustomHttpClient())
            {
                httpClient.BaseAddress = _baseAddress;
                var response = await httpClient.GetAsync(GetAllContactsDetailsUrl);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsAsync<IList<Contact>>();
                return result;
            }
            
        }

        public async Task<bool> CreateContactDetails(Contact contact)
        {
            using (var httpClient = new CustomHttpClient())
            {
                httpClient.BaseAddress = _baseAddress;


                var response = await httpClient.PostAsJsonAsync(CreateContactDetailsUrl,contact);

                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsAsync<bool>();
                return result;
            }
        }

        public async Task<Contact> GetDetails(decimal id)
        {
            using (var httpClient = new CustomHttpClient())
            {
                httpClient.BaseAddress = _baseAddress;

                var requesUrl = string.Format(GetDetailsUrl, id);

                var response = await httpClient.GetAsync(requesUrl);

                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsAsync<Contact>();
                return result;
            }
        }
    }
}
