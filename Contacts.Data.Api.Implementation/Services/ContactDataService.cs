using Contacts.Data.Api.Implementation.DataContext;
using Contacts.Data.Api.Services;
using Contacts.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Data.Api.Implementation.Services
{
    public class ContactDataService: IContactDataService
    {
        #region Declaration
        private readonly ContactDbContext context = new ContactDbContext();
        #endregion

        #region IContactDataService Implementation
        public async Task<bool> CreateContactDetails(Contact contact)
        {
            contact.ID=context.GetNextSequenceValue();

            context.Contacts.Add(contact);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return true;

        }

        public async Task<IList<Contact>> GetAllContactsDetails()
        {
            return await context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactByID(decimal id)
        {
            var result = await context.Contacts.FindAsync(id);
            return result;
        }
        #endregion IContactDataService Implementation


        #region IDisposable Implementations
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }

                disposedValue = true;
            }
        }

        ~ContactDataService()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion IDisposable Implementations
    }
}
