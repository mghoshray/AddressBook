using AddressBookApp;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace AddressBookTest
{
    [Binding]
    public sealed class AddressBookFeatureSteps
    {
        private Contact contact = new Contact();
        private AddressBook addressbook = new AddressBook();
        private List<Contact> result;

        [Given(@"I have entered an address book contact")]
        public void GivenIHaveEnteredAnAddressBookContact()
        {
            contact = new Contact("Madhumita", "Ray", 07896715916);
            addressbook.AddContact(contact);
        }

        [When(@"I click enter")]
        public void WhenIClickEnter()
        {
            //Wont do anything for this as we still dont have an UI
            
        }

        [When(@"I update the detail")]
        public void WhenIUpdateTheDetail()
        {
            contact.PhoneNumber = 123456789;
            addressbook.UpdateContact(contact);
        }

        [When(@"I delete the same")]
        public void WhenIDeleteTheSame()
        {
            addressbook.DeleteContact(contact);
        }

        [When(@"I search the same with (.*)")]
        public void WhenISearchTheSameWith(string searchcriteria)
        {
            switch (searchcriteria)
            {
                case "firstname":
                    result = addressbook.GetContactByFirstName(contact.FristName);
                    break;
                case "lastname":
                    result = addressbook.GetContactByLastName(contact.LastName);
                    break;
                case "phonenumber":
                    result = addressbook.GetContactByPhoneNumber(contact.PhoneNumber);
                    break;
                default:
                    break;
            }
            
        }

        [When(@"I search the same")]
        public void WhenISearchTheSame()
        {
            result = addressbook.GetContactByFirstName(contact.FristName);
        }

        [Then(@"I should see one contact in the book")]
        public void ThenIShouldSeeOneContactInTheBook()
        {
            //search the database and it should return one record
            Debug.Assert(addressbook.GetContactById(contact.ContactId).FristName == "Madhumita");
        }

        [Then(@"It should be updated")]
        public void ThenItShouldBeUpdated()
        {
            Debug.Assert(addressbook.GetContactById(contact.ContactId).PhoneNumber == 123456789);
        }

        [Then(@"It should be deleted")]
        public void ThenItShouldBeDeleted()
        {
            Debug.Assert(addressbook.GetContactById(contact.ContactId) == null);
        }

        [Then(@"It should be found")]
        public void ThenItShouldBeFound()
        {
            Debug.Assert(result.GetType() == typeof(List<Contact>) && result != null);
        }
    }
}
