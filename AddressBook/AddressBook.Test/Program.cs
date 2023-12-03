using System;
using System.Collections.Generic;
using AddressBook.Data;

namespace AddressBook.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var filePath = @"D:\Contacts.dat";
            //var contacts = new List<Contact>()
            //{
            //    new Contact(1, "Irakli", "Gendzekhadze", "571006565", "ikagend94@gmail.com", "Tbilisi")
            //};
            //FileManager.SaveContacts(contacts, filePath);

            //var loadedContacts = FileManager.LoadContacts(filePath);
            //foreach (var contact in loadedContacts)
            //{
            //    Console.WriteLine(contact.Id);
            //}


            ContactManager cm = new ContactManager();

            cm.Add(new Contact(4));
            cm.Add(new Contact(2));
            cm.Add(new Contact(3, "Giorgi", "Papiashvili", "--", "Gmail", "Tbilisi"));
            cm.Edit(new Contact(2, "Firstname", "Lastname", "Phone","Mail", "Address"));


            cm.Search("Papiashvili");
         

            //foreach (var cont in ct)
            //{
            //    Console.WriteLine();
            //}


        }
    }
}
