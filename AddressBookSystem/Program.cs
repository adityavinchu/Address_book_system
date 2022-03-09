using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class Program
    {
        public static void Find(Dictionary<string, Contacts> phonebooks, string name)
        {
            List<AddressBook> list = new List<AddressBook>();
            foreach (var contact in phonebooks)
            {
                list = (contact.Value.contact.FindAll(e => e.State == name | e.City == name).ToList());
                bool find = true;
                foreach (AddressBook item in list)
                {
                    if (find)
                    {
                        Console.WriteLine(contact.Key);
                        find = false;
                    }
                    Console.WriteLine(item.FirstName + " " + item.LastName);
                }
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, Contacts> Adressbooks = new Dictionary<string, Contacts>();
            Contacts first = new Contacts("FirstUser");
            Adressbooks.Add("FirstUser", first);
            Contacts second = new Contacts("SecondUser");
            Adressbooks.Add("SecondUser", second);
            Adressbooks["FirstUser"].Phonebook();
            Adressbooks["SecondUser"].Phonebook();
            Console.WriteLine("Enter the city or state name by which you want to search");
            string choice = Console.ReadLine();
            Find(Adressbooks, choice);
 
        }
    }
}
