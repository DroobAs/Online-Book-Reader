using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    class History_session
    {
        Book _current_book;
        public string session_dateTime;
        public static bool active_session = false;

        public History_session(Book b)
        {
            session_dateTime = DateTime.Now.ToString();
            _current_book = b;
        }

        public void display_history()
        {
                Console.WriteLine("------------- History -------------");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("ID            Name            Category     Number of pages");
                Console.WriteLine("");
                _current_book.book_details();
                Console.WriteLine($"Last Read in: {session_dateTime}");
        }

        public void remove_session()
        {
            _current_book = new Book();
            session_dateTime = "";
            active_session = false;
        }

    }
}
