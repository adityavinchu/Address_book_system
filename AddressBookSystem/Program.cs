using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            Dictionary<string, Contacts> Addressbooks = new Dictionary<string, Contacts>();
            Contacts book = new Contacts("BookOne");
            Addressbooks.Add("BookOne", book);
            string file = @"C:\Users\Aditya\source\Address_book_system\AddressBookSystem\CsvFile.csv";


            using (var reader =new StreamReader(file))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressBook>().ToList();
                foreach (AddressBook record in records)
                {
                    book.AddContactFileOP(record);
                }
                book.Phonebook();
            }
            using (var writer = new StreamWriter(file))
            using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvExport.WriteRecords(book.contact);
            }
        }
    }
}
