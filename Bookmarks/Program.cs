using ConsoleTools.Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarks
{
    class Program
    {
        public static List<Bookmark> BookmarkList = new List<Bookmark>();
        static SaveBookmarks Save = new SaveBookmarks();

        static void Main(string[] args)
        {
            bool shouldExit = false;

            ConsoleMenu menu = new ConsoleMenu(new[] {
                new GeneralOption("Dodaj nową zakładkę", AddBookmark),
                new GeneralOption("Zapisz zakładki w pliku JSON", SaveBookmarks),
                new GeneralOption("Otwórz zakładkę w przeglądarce", OpenBookmark),
                new GeneralOption("Exit", () => shouldExit = true),
                });

            do
            {
                menu.Show();
            } while (!shouldExit);
        }

        private static void AddBookmark()
        {
            Console.WriteLine("Podaj nazwę zakładki");
            string name = Console.ReadLine();

            Console.WriteLine("Podaj adres strony");
            string url = Console.ReadLine();

            Bookmark bookmark = new Bookmark();

            using (var context = new BookmarkContext())
            {
                bookmark.Name = name;
                bookmark.URL = url;
                context.MyBookmarks.Add(bookmark);
                context.SaveChanges();
            }

            BookmarkList.Add(bookmark);
        }

        private static void SaveBookmarks()
        {
            Console.WriteLine("podaj ścieżkę do jakiej chcesz zapisac zakładki");
            string path = Console.ReadLine();

            using (var context = new BookmarkContext())
            {
                foreach (var bookmark in context.MyBookmarks)
                {
                    BookmarkList.Add(bookmark);
                }
            }

            string pathToFile = Path.Combine(path, "Bookmarks", "bookmarks.json");

            Save.SerializeBookmarks(BookmarkList, pathToFile);
        }

        private static void OpenBookmark()
        {
            Console.WriteLine("Zakładki do wyboru:");
            using (var context = new BookmarkContext())
            {
                foreach (var bookmark in context.MyBookmarks)
                {
                    Console.WriteLine(bookmark);
                }
            }
            Console.WriteLine();

            Console.WriteLine("Podaj nazwę zakładki jaką chcesz otworzyć");
            string name = Console.ReadLine();

            using (var context = new BookmarkContext())
            {
                var bookmark = context.MyBookmarks.FirstOrDefault(b => b.Name == name);

                if (bookmark != null)
                {
                    System.Diagnostics.Process.Start(bookmark.URL);
                }
                else
                    Console.WriteLine("Nie ma takiej zakładki");
            }
        }
    }
}
