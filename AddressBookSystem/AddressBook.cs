using AddressBookSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AddressBookSystem
{
    public class AddressBook
    {
        Nlog nlog = new Nlog();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public void AddContact()
        {
            try
            {
                Console.WriteLine("Enter the First Name");
                this.FirstName = Console.ReadLine();
                Console.WriteLine("Enter the Last Name");
                this.LastName = Console.ReadLine();
                Console.WriteLine("Enter the Address");
                this.Address = Console.ReadLine();
                Console.WriteLine("Enter the City");
                this.City = Console.ReadLine();
                Console.WriteLine("Enter the State");
                this.State = Console.ReadLine();
                Console.WriteLine("Enter the Zip");
                this.Zip = Console.ReadLine();
                Console.WriteLine("Enter the PhoneNumber");
                this.Phonenumber = Console.ReadLine();
                Console.WriteLine("Enter the Email");
                this.Email = Console.ReadLine();

                Console.WriteLine("Contact Added\n");
                nlog.LogInfo("New Contact Created");

            }
            catch
            {
                nlog.LogError("Some Error Occured");
            }
        }


    }
}