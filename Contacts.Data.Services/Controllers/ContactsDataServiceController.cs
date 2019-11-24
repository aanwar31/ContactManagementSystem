using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Contacts.Data.Api.Implementation.DataContext;
using Contacts.Data.Api.Services;
using Contacts.Data.Domain.Model;

namespace Contacts.Data.Services.Controllers
{
    [RoutePrefix("api/Contacts")]
    public class ContactsDataServiceController : ApiController
    {
        private ContactDbContext db = new ContactDbContext();
        private readonly IContactDataService _contactDataService;

        public ContactsDataServiceController(IContactDataService contactDataService)
        {
            this._contactDataService = contactDataService;
        }

        [HttpGet]
        [Route("Ping")]
        public string Ping()
        {
            var result = DateTime.Now.ToString();

            return result;
        }

        [HttpGet]
        [Route("GetAllContactsDetails")]
        public async Task<IList<Contact>> GetAllContactsDetails()
        {
            return await _contactDataService.GetAllContactsDetails();
        }

        [HttpGet]
        [Route("GetContactByID/{id}")]
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> GetContactByID(decimal id)
        {
            var result = await _contactDataService.GetContactByID(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("CreateContact")]
        public async Task<IHttpActionResult> CreateContact(Contact contact)
        {
            var result = await _contactDataService.CreateContactDetails(contact);

            return Ok(result);

        }
        // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContact(decimal id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.ID)
            {
                return BadRequest();
            }

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contacts
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contacts.Add(contact);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContactExists(contact.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = contact.ID }, contact);
        }

        // DELETE: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> DeleteContact(decimal id)
        {
            Contact contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            db.Contacts.Remove(contact);
            await db.SaveChangesAsync();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(decimal id)
        {
            return db.Contacts.Count(e => e.ID == id) > 0;
        }
    }
}