using System.Collections.Generic;
using System.IO;

namespace AddressBook.Data
{
    internal static class FileManager
    {
        public static IEnumerable<Contact> LoadContacts(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }

            var contacts = new List<Contact>();
            using (var binaryReader = new BinaryReader(new FileStream(filePath, FileMode.Open)))
            {
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    var contact = new Contact(
                        id: binaryReader.ReadInt32(),
                        firstName: binaryReader.ReadString(),
                        lastName: binaryReader.ReadString(),
                        phone: binaryReader.ReadString(),
                        email: binaryReader.ReadString(),
                        address: binaryReader.ReadString()
                    );
                    contacts.Add(contact);
                }
            }

            return contacts;
        }

        public static void SaveContacts(IEnumerable<Contact> contacts, string filePath)
        {
            using (var binaryWriter = new BinaryWriter(new FileStream(filePath, FileMode.Create)))
            {
                foreach (var contact in contacts)
                {
                    binaryWriter.Write(contact.Id);
                    binaryWriter.Write(contact.FirstName);
                    binaryWriter.Write(contact.LastName ?? string.Empty);
                    binaryWriter.Write(contact.Phone ?? string.Empty);
                    binaryWriter.Write(contact.Email ?? string.Empty);
                    binaryWriter.Write(contact.Address ?? string.Empty);
                }
            }
        }
    }
}
