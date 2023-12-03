using System;

namespace AddressBook.Data
{
    public class Contact
    {
        public Contact(int id)
        {
            Id = id;
        }

        public Contact(int id, string firstName, string lastName, string phone, string email, string address) : this(id)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName;
            Phone = phone;
            Email = email;
            Address = address;
        }

        //todo: moipiqret gza rom ID-s shecvla shemedzlos mxolod am dllidan.

        internal int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"{Id},{FirstName}-{LastName},{Phone},{Email},{Address}";
        }
    }
}
