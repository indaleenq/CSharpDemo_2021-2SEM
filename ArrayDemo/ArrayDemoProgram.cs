using System;
using System.Collections.Generic;

namespace ArrayDemo
{
    class ArrayDemoProgram
    {
        static void Main(string[] args)
        {
            //option 1:
            //string[] booktitles; //declaration
            //booktitles = new string[4]; //initialization

            //option 2:
            //string[] booktitles = new string[4];

            //option 3: (implicit data type)
            //var booktitles = new string[4];

            //booktitles[0] = "Brain Rules";
            //booktitles[1] = "Pragmatic Programmer";
            //booktitles[2] = "Harry Potter and the Half-blood Prince";
            //booktitles[3] = "The Alchemist";

            var booktitles = new[]
                {"Brain Rules", "Pragmatic Programmer",
                "Harry Potter and the Half-blood Prince",
                "The Alchemist"};

            booktitles.SetValue("Harry Potter", 2);
            var indexOfPragmatic = Array.IndexOf(booktitles, "Pragmatic Programmer");

            for (int i = 0; i < booktitles.Length; i++)
            {
                booktitles[i] = booktitles[i].ToUpper();
            }

            //foreach (var title in booktitles)
            //{
            //    Console.WriteLine($"The book title is {title}");
            //}


            string[,] books = //string{[2,4]}
                {
                    {"Brain Rules",
                     "Pragmatic Programmer",
                     "Harry Potter and the Half-blood Prince",
                     "The Alchemist"
                    }, //first dimension
                    {"John Medina",
                     "Andy Hunt",
                     "J.K. Rowling",
                     "Paulo Coelho"
                    } //second dimension
                };

            for (int titleIndex = 0; titleIndex < books.GetLength(0) - 1; titleIndex++)
            {
                for (int authorIndex = 0; authorIndex < books.GetLength(1); authorIndex++)
                {
                    Console.WriteLine($"{books[titleIndex, authorIndex]} " +
                        $"by {books[titleIndex + 1, authorIndex]}");
                }
            }
        }
    }
}
