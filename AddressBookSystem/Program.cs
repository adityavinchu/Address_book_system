using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class Program
    {
       
        public static void Main(string[] args)
        {
            Contacts book = new Contacts("FirstBook");
            book.Phonebook();
        }
    }
}
