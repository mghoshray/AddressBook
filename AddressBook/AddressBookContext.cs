using System.Data.Common;
using System.Data.Entity;

namespace AddressBookApp
{
    public class AddressBookContext : DbContext
    {
        public AddressBookContext(DbConnection connection)
            : base(connection, true)
        {
        }
        internal virtual DbSet<Contact> Contacts
        {
            get { return Set<Contact>(); }
        }
    }
}
