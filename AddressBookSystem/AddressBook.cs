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
    }
}