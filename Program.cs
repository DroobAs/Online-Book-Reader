using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    enum Gender
    {
        Male = 0,
        Female = 1,
        unassiend
    }


    class Program
    {
        #region All Data
        //---------Users------------

        public static List<users> users_list = new List<users>();

        //---------Books------------

        public static List<Book> Book_list = new List<Book>();

        #endregion

        public static int choice = -1;
        public static bool exit = false;
        public static bool loggedin = false;
        public static users current_user;
        public static Book current_book;
        public static Book Edit_book;
        public static Book Delete_book;
        public static int current_page = 1;
        public static History_session history;
        public static bool isAdmin = false;


        static void begin()
        {
            Console.Clear();
            Console.WriteLine("Welcome on Online Book Reader");
            Console.WriteLine("Hope you good journey");
            Console.WriteLine("Please, Log in or Register to Read Book you want :))");
            Console.WriteLine("");
            Console.WriteLine("");
       
            Console.WriteLine("1. login");
            Console.WriteLine("2. Register");
            Console.WriteLine("");
            Console.WriteLine("0. Exit");
            Console.WriteLine("");

            Console.Write("Enter Your choice:");
            choice = int.Parse(Console.ReadLine());
        }

        #region Loggin & Register

        public static bool login(ref string _mail, ref string _pass, ref users v_user, ref bool admin)
        {
            bool found = false;
            Console.WriteLine("Enter your email: ");
            _mail = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            _pass = Console.ReadLine();

            foreach (var item in users_list)
            {
                if (item.Email == _mail && item.Password == _pass)
                {
                    v_user = item;
                    found = true;
                    if (item.Email == "Asmaa@gmail.com")
                    {
                        admin = true;
                    }
                    loggedin = true;
                    break;
                }
            }
            return found;
        }

        public static void Register()
        {
            Console.Clear();
            Console.Write("Enter Your Name: ");
            string _name = Console.ReadLine();
            Console.WriteLine("");

            Console.Write("Enter Your Age: ");
            int _age = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("1. Famale.");
            Console.WriteLine("0. Male.");
            Console.Write("Your Gender: ");
            int _gend = int.Parse(Console.ReadLine());
            int _yes = 0;
            Gender gen = Gender.unassiend;
            if (_gend == 1)
            {
                gen = Gender.Female;
                _yes = 1;
            }
            else if (_gend == 0)
            {
                gen = Gender.Male;
                _yes = 1;
            }
            Console.WriteLine("");

            Console.Write("Enter Your Email: ");
            string _email = Console.ReadLine();
            Console.WriteLine("");

            Console.Write("Enter Your Password: ");
            string _pass = Console.ReadLine();

            if (_email.Contains('@') && _email.Contains('.') && _pass.Length >= 7 && _yes == 1)
            {
                users newuser = new users(_email, _pass, _name, gen, _age);
                users_list.Add(newuser);
                Console.Clear();
                Console.WriteLine("Your Register has completed succesfully");
                Console.WriteLine("");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please, Enter Your Data Correctly.");
                Console.WriteLine("These Instruction May be help you:");
                Console.WriteLine("- sure that You Set Your mail Correctly.");
                Console.WriteLine("- sure that Your password lenght greater than or equal 7 characters.");
                Console.WriteLine("- sure that you set Gender = 0 or 1.");
                Console.WriteLine("");
                Console.WriteLine("Press any key to continue");

                Console.ReadLine();
                Register();
            }

        }

        public static void logged()
        {
            string mail = "", pass = "";

            Console.Clear();
            bool isfound = login(ref mail, ref pass, ref current_user, ref isAdmin);

            if (isfound == true)
            {
                if (isAdmin == true)
                {
                    Console.WriteLine("yeees found Admin");
                }
                else
                {
                    Console.WriteLine("yeees found user");
                }
            }
            else
            {
                Console.WriteLine("Email or password maybe wrong!");
                Console.ReadLine();
                logged();
            }

        }


        #endregion

        public static void beginexplore()
        {
            Console.Clear();
            Console.WriteLine($"Welcome {current_user.name}");
            Console.WriteLine("");

            Console.WriteLine("1. Explore All Books");
            Console.WriteLine("2. Show Your History");
            Console.WriteLine("3. My Profile");
            Console.WriteLine("4. log out");

            if (isAdmin == true)
            {
                Console.WriteLine("5. More Options");
            }

            Console.WriteLine("0. Exit");
            Console.WriteLine("");

            Console.Write("Enter Your Choice: ");
            choice = int.Parse(Console.ReadLine());
        }

        public static void History()
        {
            Console.Clear();
            if (History_session.active_session == true)
            {
                history.display_history();

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("_____________________________________________");
                Console.WriteLine("1. complete Reading     2. Remove session     -1. Return Back      0. Exit");
                Console.Write("Enter: ");
                int history_option = int.Parse(Console.ReadLine());

                switch (history_option)
                {
                    case 0:
                        {
                            Console.WriteLine("*** Good Bye ***");
                            exit = true;
                            break;
                        }
                    case 1: // Complete Reading
                        {
                            current_book.Read_Book(ref current_page);
                            break;
                        }
                    case 2: // Remove session
                        {
                            history.remove_session();
                            History();
                            break;
                        }
                    case -1: // Return Back
                        {
                            core_programm();
                            break;
                        }
                    default:
                        {
                            Console.Write("Choose correct option!");
                            Console.ReadLine();
                            History();
                            break;
                        }
                }

            }
            else
            {
                Console.WriteLine("There is No Active session!");
                Console.ReadLine();
                core_programm();
            }
            exit = true;
        }

        public static void Back_Exit_Read()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("presss: ");
            Console.WriteLine("ID of book to Read it");
            if (isAdmin == true)
            {
                Console.WriteLine("-2. More option");
            }
            Console.WriteLine("-1 to Return Back");
            Console.WriteLine("0 to Exit");

            int decition = int.Parse(Console.ReadLine());
            void loob()
            {
                bool book_found = false;
                if (decition == -1)
                {
                    core_programm();
                }
                else if (decition == -2)
                {
                    if (isAdmin == true)
                    {
                        More_options();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You is not allowed to access this page!");
                        Console.ReadLine();
                        Explore();
                    }
                }
                else if (decition == 0)
                {
                    Console.WriteLine("*** Good Bye ***");
                    exit = true;
                }

                else if (decition <= Book.ID && decition > 0)
                {
                    foreach (var _book in Program.Book_list)
                    {
                        if(_book.id == decition)
                        {
                            current_book = _book;
                            history = new History_session(current_book);
                            History_session.active_session = true;
                            book_found = true;
                        }
                    }

                    Console.Clear();
                    if (book_found == true)
                    {
                        current_book.Read_Book( ref current_page);
                        history.session_dateTime = DateTime.Now.ToString();
                    }
                    else
                    {
                        Console.WriteLine("Book is not available!");
                        Console.ReadLine();
                        Explore();
                    }

                }
                else
                {
                    Console.Write("choose correct choice: ");
                    decition = int.Parse(Console.ReadLine());

                    loob();
                }
            }
            loob();

        }


        public static void Back_Exit_Only()
        {
            exit = false;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("presss: ");
            Console.WriteLine("-1 to Return Back");
            Console.WriteLine("0 to Exit");

            int B_E = int.Parse(Console.ReadLine());
            void loobEB()
            {
                if (B_E == -1)
                {
                    core_programm();
                }
                else if (B_E == 0)
                {
                    Console.WriteLine("*** Good Bye ***");
                    exit = true;
                }
                else
                {
                    Console.Write("choose correct choice: ");
                    B_E = int.Parse(Console.ReadLine());

                    loobEB();
                }
            }
            loobEB();
        }

        public static void Edit()
        {
            Console.Clear();
            current_user.view_current_books();
            Console.WriteLine("");

            current_user.Edit_Book(ref Edit_book);

            Console.Clear();
            Console.WriteLine("Book info: ");
            Console.WriteLine("");
            Edit_book.book_details();
            Console.WriteLine("");
            Console.WriteLine("_________________________________________");
            Console.WriteLine("");

            Console.WriteLine("1. to edit name     2. to edit category     3. to edit content     4. to edit all content     -1. to Return Back");
            Console.WriteLine("");
            Console.WriteLine("");
            int edit = int.Parse(Console.ReadLine());

            switch (edit)
            {
                case 1: //Edit Name
                    {
                        Console.Write("Enter New Book Name: ");
                        Edit_book.name = Console.ReadLine();
                        Console.WriteLine("");
                        break;
                    }
                case 2: // Edit category
                    {
                        Console.Write("Enter Book Category: ");
                        Edit_book.category = Console.ReadLine();
                        Console.WriteLine("");
                        break;
                    }
                case 3: // Edit Content
                    {
                        Console.Write("Enter Number of Page you want edit: ");
                        int pnum = int.Parse(Console.ReadLine());

                        if (pnum > 0 && pnum <= Edit_book.Number_of_pages)
                        {
                            Console.WriteLine($"Add content of page {pnum}");
                            Edit_book.content[pnum - 1] = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Page is not exist!");
                        }

                        break;
                    }
                case 4: // Edit All Content
                    {
                        Console.Write("Enter Total Number of Pages: ");
                        Edit_book.Number_of_pages = int.Parse(Console.ReadLine());
                        Console.WriteLine("");
                        string[] _content = new string[Edit_book.Number_of_pages];

                        Console.WriteLine("Adding New Content ...");
                        for (int i = 0; i < Edit_book.Number_of_pages; i++)
                        {
                            Console.WriteLine($"Add content of page {i + 1}");
                            Edit_book.content[i] = Console.ReadLine();
                        }
                        break;
                    }
                case -1:
                    {
                        More_options();
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Option Not valid!!");
                        Console.ReadLine();
                        Edit();
                        break;
                    }
            }


            Console.Clear();
            Console.WriteLine("Your Book has updated successfully!");
            Console.ReadLine();
            Explore();

        }

        public static void More_options()
        {
            Console.Clear();
            Console.WriteLine("Admins Options");
            Console.WriteLine("");

            Console.WriteLine("1. Add New Book");
            Console.WriteLine("2. Edit Book");
            Console.WriteLine("3. Delete Book");
            Console.WriteLine("-1. Return Back");

            Console.Write("Enter Your Choice: ");
            int admin_choice = int.Parse(Console.ReadLine());

            switch(admin_choice)
            {
                case 1: //Add Book
                    {
                        Console.Clear();
                        Book_list.Add( current_user.Add_Book() );
                        Console.Clear();
                        Console.WriteLine("Your Book has Added successfully!");
                        Console.ReadLine();
                        Explore();

                        break;
                    }
                case 2: // Edit Book
                    {
                        Edit();
                        break;
                    }
                case 3: // Delete Book
                    {
                        Console.Clear();
                        bool deleted = false;
                        current_user.view_current_books();
                        Console.WriteLine("");
                        current_user.Delete_Book(ref Delete_book, ref deleted);

                        if (deleted == true)
                        {
                            Book_list.Remove(Delete_book);
                            Console.Clear();
                            Console.WriteLine("your Book Has Deleted successfully!");
                            Console.ReadLine();
                            Explore();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("There is no book with this id found!");
                            Console.ReadLine();
                            More_options();
                        }

                       

                        break;
                    }
                case -1: // Return Back
                    {
                        core_programm();
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Please, Choose correct option!");
                        Console.ReadLine();
                        More_options();
                        break;
                    }
            }
        }

        public static void Explore()
        {
            Console.Clear();
            if ( Book_list.Count == 0 )
            {
                Console.WriteLine("Sorry, There is No Book found!");
                Console.ReadLine();
                core_programm();
            }
            else
            {
                current_user.view_current_books();
                Back_Exit_Read();
            }
        }

        //--------------------------------------------------------
        public static void After_Login_choice()
        {
            choice = -1;
            if (loggedin == false)
            {
                logged();
            }
            core_programm();
            
        }

        public static void core_programm()
        {
            choice = -1;
            exit = false;

            if (loggedin == true)
            {
                beginexplore();

                while (exit == false)
                {
                    switch (choice)
                    {
                        case 1: // Explore
                            {
                                Explore();
                                exit = true;
                                break;
                            }
                        case 2: //History
                            {
                                History();
                                break;
                            }
                        case 3: //Profile
                            {
                                Console.Clear();
                                current_user.view_Profile();
                                Back_Exit_Only();
                                exit = true;
                                break;
                            }
                        case 4: //logout
                            {
                                isAdmin = false;
                                loggedin = false;
                                After_Login_choice();
                                exit = true;
                                break;
                            }
                        case 5: //More options
                            {
                                if (isAdmin == true)
                                {
                                    More_options();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You don't allowed to access this page!");
                                    Console.ReadLine();
                                    core_programm();
                                }
                                break;
                            }

                        case 0: //Exit
                            {
                                Console.WriteLine("*** Good Bye ***");
                                exit = true;
                                break;
                            }
                        default:
                            {
                                Console.Clear();
                                Console.Write("Please choose correct choice");
                                Console.ReadLine();
                                beginexplore();
                                break;
                            }
                    }
                }
            }
        }

        //------------------------------------------ Project -----------------------------------------------
        public static void online_book_reader()
        {
            begin();

            while (exit == false)
            {

                if (choice == 0) // Exit
                {
                    Console.WriteLine("*** Good Bye ***");
                    exit = true;
                }
                else if (choice == 1) //Login
                {
                    After_Login_choice();
                    exit = true;
                }
                else if (choice == 2) // Register
                {
                    Console.Clear();
                    Register();
                    After_Login_choice();
                    exit = true;
                }
                else
                {
                    Console.Clear();
                    Console.Write("Please choose correct choice");
                    Console.ReadLine();
                    begin();
                }

            }


            Console.ReadLine();
        }


//******************************************** Main *************************************************
        static void Main(string[] args)
        {
            #region set Data
            Admins u1 = new Admins("Asmaa@gmail.com", "123asmaa", "Asmaa", Gender.Female, 22);
            users u2 = new users("user@gmail.com", "123rania", "Rania", Gender.Female, 24);
            string[] cont_b1 = new string[3] { "page1", "page2", "page3" };
            Book b1 = new Book("From Zero To Hero", 3, cont_b1, "science");



            users_list.Add(u1);
            Book_list.Add(b1);
            users_list.Add(u2);

            #endregion

            online_book_reader();

        }
    }
}
