namespace Contacts.Data.Api.Implementation.DataContext
{
    using Contacts.Data.Domain.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ContactDbContext : DbContext
    {
        // Your context has been configured to use a 'ContactDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Contacts.Data.Api.Implementation.DataContext.ContactDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ContactDbContext' 
        // connection string in the application configuration file.
        public ContactDbContext()
            : base("name=ContactDbContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ContactDbContext>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public int GetNextSequenceValue()
        {
            var rawQuery = Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.SequenceCounter;");
            var task = rawQuery.SingleAsync();
            int nextVal = task.Result;

            return nextVal;
        }

        protected virtual void InitializeDatabase()
        {
            if (!Database.Exists())
            {
                Database.Initialize(true);
                new DatabaseInitializer();
            }
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}