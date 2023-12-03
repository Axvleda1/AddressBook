using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook.Data
{
    public class ContactManager
    {
        private IList<Contact> _contacts;

        public void Load(string filePath)
        {
            _contacts = FileManager.LoadContacts(filePath).ToList();
        }

        public void Save(string filePath)
        {
            FileManager.SaveContacts(_contacts, filePath);
        }

        public void Add(Contact contact)
        {

            if (_contacts == null)
            {
                _contacts = new List<Contact>(); 
                       
            }

            contact.Id = GetNewId();
            _contacts.Add(contact);
        }

        public void Edit(Contact contact)
        {
            foreach (var cont in _contacts)
            {
                if (cont.Id == contact.Id)
                {
                    cont.FirstName = contact.FirstName;
                    cont.LastName = contact.LastName;
                    cont.Phone = contact.Phone;
                    cont.Email = contact.Email;
                    cont.Address = contact.Address;
                }
            }
        }

        public void Delete(int id)
        {
            foreach (var cont in _contacts)
            {
                if (cont.Id == id)
                {
                    _contacts.Remove(cont);
                }
            }
        }

        public IEnumerable<Contact> Search(string pattern)
        {
            var searchedContacts = new List<Contact>();

            foreach (var cont in _contacts)
            {
                if (cont.ToString().Contains(pattern))
                {
                    searchedContacts.Add(cont);
                }
            }

            return searchedContacts;
            //throw new NotImplementedException();
        }

        public int GetNewId()
        {
            int MaxId = 0;

            if (_contacts == null || _contacts.Count == 0)
            {
                return 1;
            }

            foreach (var cont in _contacts)
            {
                if (cont.Id > MaxId)
                {
                    MaxId = cont.Id;
                }
            }

            return MaxId + 1;
        }
    }
}
