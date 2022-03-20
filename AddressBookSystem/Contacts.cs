using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AddressBookSystem
{
    public class Contacts
    {
        public string Addressbookname;
        public Contacts(string name)
        {
            this.Addressbookname = name;
        }
        public List<AddressBook> contact = new List<AddressBook>();
        Nlog nlog = new Nlog();

        public int count = 0;
        public void NewContact()
        {
            //Console.WriteLine(contact.Count());
            try
            {
                AddressBook addressBook = new AddressBook();
                addressBook = AddContact();
                bool present = Validate(addressBook.FirstName, addressBook.LastName);
                if (present)
                {
                    Console.WriteLine("Username is already present in the contacts");
                    return;
                }
                contact.Add(addressBook);
                nlog.LogInfo("New Contact Added in Address Book");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
        public void AddContactFileOP(AddressBook addressook)
        {
            bool present =Validate(addressook.FirstName, addressook.LastName);
            if (!present)
            {
                contact.Add(addressook);
            }
        }
        public bool Validate(string firstname, string lastname)
        {
            return contact.Any(x => x.FirstName == firstname && x.LastName == lastname);
        }
        public AddressBook AddContact()
        {
            AddressBook addressBook = new AddressBook();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Enter First Name");
            addressBook.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            addressBook.LastName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            addressBook.Address = Console.ReadLine();
            Console.WriteLine("Enter City");
            addressBook.City = Console.ReadLine();
            Console.WriteLine("Enter State");
            addressBook.State = Console.ReadLine();
            Console.WriteLine("Enter Zip");
            addressBook.Zip = Console.ReadLine();
            Console.WriteLine("Enter PhoneNumber");
            addressBook.Phonenumber = Console.ReadLine();
            Console.WriteLine("Enter Email");
            addressBook.Email = Console.ReadLine();
            Console.WriteLine("----------------------------------");
            return addressBook;
        }
        public void AddContact(string s)
        {
            string[] userinfo = s.Split(' ');
            AddressBook addressBook = new AddressBook();
            addressBook.FirstName = userinfo[0];
            addressBook.LastName = userinfo[1];
            addressBook.Address = userinfo[2];
            addressBook.City = userinfo[3];
            addressBook.State = userinfo[4];
            addressBook.Zip = userinfo[5];
            addressBook.Phonenumber = userinfo[6];
            addressBook.Email = userinfo[7];
            bool present = Validate(addressBook.FirstName, addressBook.LastName);
            if (!present) contact.Add(addressBook);
        }
        public bool EditContact()
        {
            Console.WriteLine("Enter First Name");
            string Firstname = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            string Lastname = Console.ReadLine();

            foreach (AddressBook addressBook in contact)
            {
                if (addressBook.FirstName == Firstname && addressBook.LastName == Lastname)
                {
                    Console.WriteLine("Current Information About Contact");
                    Display(addressBook);
                    AddressBook temp = new AddressBook();
                    temp = Edit(addressBook);
                    contact.Remove(addressBook);
                    contact.Add(temp);
                    nlog.LogInfo("Contact updated Successfully");
                    return true;
                }
            }
            nlog.LogError("Contact not found\n");
            return false;
        }

        public AddressBook Edit(AddressBook address)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Press 1 : Update First Name");
            Console.WriteLine("Press 2 : Update Last Name");
            Console.WriteLine("Press 3 : Update Address");
            Console.WriteLine("Press 4 : Update city");
            Console.WriteLine("Press 5 : Update State");
            Console.WriteLine("Press 6 : Update Zip");
            Console.WriteLine("Press 7 : Update PhoneNumber");
            Console.WriteLine("Press 8 : Update Email");
            Console.WriteLine("----------------------------------");

            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter New Information");
            string temp = Console.ReadLine();
            switch (n)
            {
                case 1:
                    address.FirstName = temp;
                    break;
                case 2:
                    address.LastName = temp;
                    break;
                case 3:
                    address.Address = temp;
                    break;
                case 4:
                    address.City = temp;
                    break;
                case 5:
                    address.State = temp;
                    break;
                case 6:
                    address.Zip = temp;
                    break;
                case 7:
                    address.Phonenumber = temp;
                    break;
                case 8:
                    address.Email = temp;
                    break;
                default:
                    Console.WriteLine("Please select Correct Option");
                    break;
            }
            return address;
        }
        public bool DeleteContact()
        {
            Console.WriteLine("Enter First Name");
            string Firstname = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            string Lastname = Console.ReadLine();

            foreach (AddressBook addressBook in contact)
            {
                if (addressBook.FirstName == Firstname && addressBook.LastName == Lastname)
                {
                    contact.Remove(addressBook);
                    return true;
                }
            }
            nlog.LogError("Contact not found\n");
            return false;
        }
        public void Display(AddressBook address)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("First Name  :" + address.FirstName);
            Console.WriteLine("Last Name   :" + address.LastName);
            Console.WriteLine("Address     :" + address.Address);
            Console.WriteLine("City        :" + address.City);
            Console.WriteLine("State       :" + address.State);
            Console.WriteLine("Zip         :" + address.Zip);
            Console.WriteLine("Phonenumber :" + address.Phonenumber);
            Console.WriteLine("Email       :" + address.Email);
            Console.WriteLine("----------------------------------");
        }
        public void View()
        {
            Console.WriteLine("Enter option By Which you Sorted Contacts:\n");
            Console.WriteLine("Press 1: FirstName");
            Console.WriteLine("Press 2: City");
            Console.WriteLine("Press 3: State");
            Console.WriteLine("Press 4: Zip");
            Console.WriteLine("--------------------------------------------");

            int option = Convert.ToInt32(Console.ReadLine());

            if (option == 1)
                contact.Sort((emp1, emp2) => emp1.FirstName.CompareTo(emp2.FirstName));
            if(option == 2)
                contact.Sort((emp1, emp2) => emp1.City.CompareTo(emp2.City));
            if( option == 3)
                contact.Sort((emp1, emp2) => emp1.State.CompareTo(emp2.State));
            if(option == 4)
                contact.Sort((emp1, emp2) => emp1.Zip.CompareTo(emp2.Zip));
            
            
            foreach (AddressBook addressBook in contact)
            {
                Console.WriteLine(addressBook.FirstName);
                Display(addressBook);
            }
        }

        public void FindContact(string name)
        {
            //List<AddressBook> list = new List<AddressBook>();
                foreach (AddressBook contact in contact.FindAll(f => f.State == name || f.City == name).ToList())
                {
                    count++;
                    Console.WriteLine(contact.FirstName + " " + contact.LastName);
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("Contact is PRESENT\n");
                    Console.WriteLine("----------------------------------");
                }
        }

        public void Phonebook()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("____________________________________________________");
                Console.WriteLine("Press 1 : Add contact                              |");
                Console.WriteLine("Press 2 : Edit Contact                             |");
                Console.WriteLine("Press 3 : View Contact                             |");
                Console.WriteLine("Press 4 : Delete Contact                           |");
                Console.WriteLine("Press 5 : Find By City or state                    |");
                Console.WriteLine("Press 6 : Exit                                     |");
                Console.WriteLine("___________________________________________________|");

                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        NewContact();
                        break;
                    case 2:
                        bool editSuccessfully = EditContact();
                        if (editSuccessfully)
                        {
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("Contact Updated Successfully\n");
                            Console.WriteLine("----------------------------------");
                        }
                        else Console.WriteLine("No Record Found\n");
                        break;
                    case 3:
                        View();
                        break;
                    case 4:
                        bool deleted = DeleteContact();
                        if (deleted)
                        { 
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("Contact Deleted Successfully\n");
                            Console.WriteLine("----------------------------------"); 
                        }
                        else Console.WriteLine("No Record Found\n");
                        break;
                    case 5:
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("Enter city or state want to search:");
                        String CityOrState=Console.ReadLine();
                        Console.WriteLine("----------------------------------");
                        FindContact(CityOrState);

                        Console.WriteLine("Total count of persons from {0} city/state is:{1}", CityOrState , count);
                        break;
                    case 6:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Enter correct Value");
                        break;
                }
            }
        }
    }
}
