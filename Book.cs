using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    class Book
    {
        int number_of_pages;
        public string[] content;
        public static int ID = 0;

        public string name { get; set; }
        public string category { get; set; }
        public int Number_of_pages
        {
            get
            {
                return number_of_pages;
            }
            set
            {
                if (value < 1)
                {
                    number_of_pages = 1;
                }
                else
                {
                    number_of_pages = value;
                }
            }
        }
        public int id { get; set; }

        #region constructor
        public Book()
        {

        }

        public Book (string _name, int _numpage, string[] _content, string _category)
        {
            name = _name;
            Number_of_pages = _numpage;
            category = _category;
            content = _content;
            id = ++ID;
        }
           

        #endregion

        public void book_details()
        {
            Console.WriteLine($"{id}     {name}               {category}               {Number_of_pages}");
        }

        public void Read_Book(ref int _current_page)
        {
            Console.Clear();
            
            Console.WriteLine($"Name: {name}.");
            Console.WriteLine($"Category: {category}.");
            Console.WriteLine($"Number of pages: {Number_of_pages} page.");
            Console.WriteLine("_______________________________________________________");
            Console.WriteLine("");
            Console.WriteLine($"{content[_current_page - 1]}");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("_______________________________________________________");
            Console.WriteLine($"page ({_current_page})");

            Console.WriteLine("");
            Console.WriteLine("1. Next Page     2. Previes Page     -1. Return Back     0. Exit");
            int read_option = int.Parse(Console.ReadLine());

            switch(read_option)
            {
                case 0:
                    {
                        Console.WriteLine("*** Good Bye ***");
                        Program.exit = true;
                        break;
                    }
                case 1:
                    {
                        
                        if (_current_page >= Number_of_pages)
                        {
                            _current_page = 1;
                        }
                        else
                        {
                            _current_page++;
                        }

                        Read_Book(ref _current_page);
                        break;
                    }
                case 2:
                    {
                        if (_current_page <= 1)
                        {
                            _current_page = Number_of_pages;
                        }
                        else
                        {
                            _current_page--;
                        }

                        Read_Book(ref _current_page);
                        break;
                    }
                case -1:
                    {
                        Console.Clear();
                        Program.Explore();
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Please choose correct choice!");
                        Console.ReadLine();
                        Read_Book(ref _current_page);
                        break;
                    }
            }
        }

    }
}
