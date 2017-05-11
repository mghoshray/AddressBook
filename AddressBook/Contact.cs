using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookApp
{
    [Table("Contact")]
    public class Contact
    {
        public Contact() { }
        public Contact(string firstName, string lastName, long number)
        {
            FristName = firstName;
            LastName = lastName;
            PhoneNumber = number;
        }

        [Key]
        public int ContactId { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
    }
}