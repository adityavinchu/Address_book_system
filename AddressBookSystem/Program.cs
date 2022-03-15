using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class Program
    {
       
        public static void Main(string[] args)
        {
            Dictionary<string, Contacts> Adressbooks = new Dictionary<string, Contacts>();
            Contacts book = new Contacts("FirstBook");
            Adressbooks.Add("FirstBook", book);
            string file = @"C:\Users\Aditya\source\Address_book_system\AddressBookSystem\TextFile1.txt";


            if (File.Exists(file))
            {
                const Int32 BufferSize = 128;
                using (var fileStream = File.OpenRead(file))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        book.AddContact(line);
                    }
                }
                book.Phonebook();
                string temp = "";
                foreach (var user in book.contact)
                {
                    temp += user.FirstName + " " + user.LastName + " " + user.Address + " " + user.City + " " + user.State + " " + user.Zip + " " + user.Phonenumber + " " + user.Email + "\n";
                }
                File.WriteAllText(file, temp);

            }
            else
            {
                Console.WriteLine("File Does not Exist");
            }
        }
    }
}
