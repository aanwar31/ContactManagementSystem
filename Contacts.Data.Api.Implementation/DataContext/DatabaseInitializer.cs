using Contacts.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Data.Api.Implementation.DataContext
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<ContactDbContext>
    {
        protected override void Seed(ContactDbContext context)
        {
            base.Seed(context);
            var dummyData = new Contact() { 
                ID=101,
                FirstName="Aamir",
                LastName="Anwar",
                Email="aanwar31@gmail.com",
                PhoneNumber="+918759104602",
                Status="Active"
            };
            context.Contacts.Add(dummyData);
            context.SaveChanges();
        }
    }
}
