using System.Collections.Generic;
using System.Linq;


namespace AddressBookApp
{
    public class AddressBook
    {
        public AddressBook()
        {
            Context = new AddressBookContext(Effort.DbConnectionFactory.CreatePersistent("AddressBookTestContext"));
        }

        public AddressBookContext Context { get; set; }

        public void AddContact(Contact contact)
        {
            var existingRecord = GetContactById(contact.ContactId);
            if (existingRecord == null)
            {
                Context.Contacts.Add(contact);
                Context.SaveChanges();
            }
        }

        public void DeleteContact(Contact contact)
        {
            Context.Contacts.Remove(contact);
            Context.SaveChanges();
        }

        public void UpdateContact(Contact contact)
        {
            var existingRecord = GetContactById(contact.ContactId);
            if (existingRecord != null)
                Context.Entry(existingRecord).CurrentValues.SetValues(contact);
            Context.SaveChanges();
        }

        public Contact GetContactById(int id)
        {
            return Context.Contacts.SingleOrDefault(c => c.ContactId == id);
        }

        public List<Contact> GetContactByFirstName(string firstName)
        {
            return Context.Contacts.Where(c => c.FristName == firstName).ToList();
        }

        public List<Contact> GetContactByPhoneNumber(long phoneNumber)
        {
            return Context.Contacts.Where(c => c.PhoneNumber == phoneNumber).ToList();
        }

        public List<Contact> GetContactByLastName(string lastName)
        {
            return Context.Contacts.Where(c => c.LastName == lastName).ToList();
        }

        public List<Contact> GetContacts()
        {
            return Context.Contacts.ToList();
        }
    }
}
