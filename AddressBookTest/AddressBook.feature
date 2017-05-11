Feature: AddressBook
	In order to maintain an Address Book
	As an adress book maintainer
	I want to be able to insert, delete and search records


Scenario: Create a Contact
	Given I have entered an address book contact
	When I click enter
	Then I should see one contact in the book

Scenario: Update a Contact
	Given I have entered an address book contact
	When I update the detail
	Then It should be updated

Scenario: Delete a Contact
	Given I have entered an address book contact
	When I delete the same
	Then It should be deleted

Scenario Outline: Search a Contact
	Given I have entered an address book contact
	When I search the same with <searchcriteria>
	Then It should be found

Examples:
| searchcriteria |
| firstname      |
| lastname       |
| phonenumber    |

