using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    class users 
    {
        #region Attribute

        protected string email;
        protected string password;
        public string name;
        public Gender gender;
        public int age;

        #endregion

        #region Setters & Getters
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (value.Contains('@') && value.Contains('.'))
                {
                    email = value;
                }
                else
                {
                    email = null;
                }
            }
        }
        public string Password
        { 
            get
            {
                return password;
            }
            set
            {
                if (value.Length >=7)
                {
                    password = value;
                }
                else
                {
                    password = null;
                }
            }
        }

        #endregion

        #region constructor

        public users(string mail, string pass, string _name, Gender _gender, int _age)
        {
            Email = mail;
            Password = pass;
            name = _name;
            gender = _gender;
            age = _age;
        }

        #endregion

        #region Functions

        public void view_current_books()
        {
            Console.WriteLine("ID            Name            Category     Number of pages");
            foreach (var bookitem in Program.Book_list)
            {
                bookitem.book_details();
            }
            
        }

        public virtual void view_Profile()
        {
            Console.WriteLine($"******** My Profile ********");
            Console.WriteLine("");

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine("State: Reader");
        }

        public virtual Book Add_Book()
        {
            Book b = new Book();
            return b;
        }

        public virtual void Edit_Book(ref Book ebook)
        {

        }

        public virtual void Delete_Book(ref Book del_book, ref bool del)
        {

        }

        #endregion

    }


    class Admins : users
    {
        #region constructor
        public Admins(string mail, string pass, string _name, Gender _gender, int _age) : base(mail, pass, _name, _gender, _age) { }

        #endregion

        public override Book Add_Book()
        {
            Console.Write("Enter Book Name: ");
            string b_name = Console.ReadLine();
            Console.WriteLine("");

            Console.Write("Enter Book Category: ");
            string b_cat = Console.ReadLine();
            Console.WriteLine("");

            Console.Write("Enter Number of Pages: ");
            int b_Npages = int.Parse( Console.ReadLine() );
            Console.WriteLine("");
            string[] _content = new string[b_Npages];

            Console.WriteLine("Adding Content ...");
            for (int i = 0; i < b_Npages; i++)
            {
                Console.WriteLine($"Add content of page {i+1}");
                _content[i] = Console.ReadLine();
            }

            Console.WriteLine("");
            Console.WriteLine("");

            Book newbook = new Book(b_name, b_Npages, _content, b_cat);

            return newbook;
        }

        public override void Delete_Book(ref Book del_book, ref bool del)
        {
            Console.Write("Enter Book ID to Delete: ");
            int bD_id = int.Parse(Console.ReadLine());

            if (bD_id <= Book.ID && bD_id > 0)
            {
                foreach (var item in Program.Book_list)
                {
                    if (item.id == bD_id)
                    {
                        del_book = item;
                        del = true;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Book is not exist!");
                Console.ReadLine();
                Program.More_options();
                del_book = null;
            }
        }

        public override void Edit_Book(ref Book ebook)
        {
            Console.Write("Enter Book ID to Edit: ");
            int b_id = int.Parse( Console.ReadLine() );

            if (b_id <= Book.ID && b_id > 0)
            {
                foreach (var item in Program.Book_list)
                {
                    if (item.id == b_id)
                    {
                        ebook = item;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Book is not exist!");
                Console.ReadLine();
                Program.More_options();
                ebook = null;
            }
        }

        public override void view_Profile()
        {
            Console.WriteLine($"******** My Profile ********");
            Console.WriteLine("");

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine("State: Admin");

        }
    }
}
