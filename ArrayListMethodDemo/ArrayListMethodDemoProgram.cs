using System;
using System.Collections.Generic;

namespace ArrayListMethodDemo
{
    class ArrayListMethodDemoProgram
    {
        static void Main(string[] args)
        {
            var booktitles = new[] {"Brain Rules",
                            "Pragmatic Programmer",
                            "Harry Potter and the Half-Blood Prince",
                            "The Alchemist",
                            "Deep Work",
                            "The Alchemist"};

            var indexOfAlchemist = Array.IndexOf(booktitles, "The Alchemist");
            booktitles.SetValue("The Spy", 5);

            for (int i = 0; i < booktitles.Length; i++)
            {
                booktitles[i] = booktitles[i].ToUpper();
            }

            foreach (var title in booktitles)
            {
                Console.WriteLine($"Title is {title}");
            }

            var books = new List<string>()
                {"Brain Rules","Pragmatic Programmer",
                 "Harry Potter and the Half-Blood Prince",
                 "The Alchemist","Deep Work"};
            books.Add("HP 2");
            var newBooks = new List<string>() { "Book 1", "Book 2" };
            books.AddRange(newBooks);
            books.Insert(3, "HP 3");
            books.Remove("HP 2");
            books.Remove("HP 3");

            foreach (var title in books)
            {
                Console.WriteLine($"Title is {title}");
            }

            List<string> authors = new List<string>();
            DisplayElements(authors);
        }

        static void DisplayElements(List<string> collections)
        {
            Display(collections);
        }
        static void DisplayElements(string[] stringArray)
        {
            Display(stringArray);
        }

        static void Display(IEnumerable<string> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine("Item is " + item);
                Console.WriteLine();
            }
        }

       

    }
}
