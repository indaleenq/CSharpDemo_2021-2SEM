using System;
using System.Collections.Generic;

namespace ArrayDemo
{
    class ArrayDemoProgram
    {
        static void Main(string[] args)
        {

            var booktitles = new List<string>() { "Brain Rules", "PragmaticProgrammer", 
                "Harry Potter and the Half-Blood Prince", "The Alchemist" };

            //retrieving an element from an array
            Console.WriteLine(booktitles[0]);
            Console.WriteLine(booktitles[1]);
            Console.WriteLine(booktitles[2]);
            Console.WriteLine(booktitles[3]);


            //var books = new List<string>() { "HPs", "The Alchemist" };
            var books = new List<string>();
            ArrayDemoProgram first = new ArrayDemoProgram();

            first.DisplayElements(books);
            first.Test("hello");
        }

        public void DisplayElements(List<string> collections)
        {
            if (collections.Count > 0) {
                foreach (var item in collections)
                {
                    Console.WriteLine("Item is " + item);
                }
            }
        }

        public void Test(string y, int x = 2)
        {
            Console.WriteLine(x);
            Console.WriteLine(y);
        }
    }
}
