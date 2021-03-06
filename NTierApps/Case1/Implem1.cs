using System;
using System.Collections.Generic;

namespace Implem1
{
    class Program
    {
        static List<string> actions = new List<string>()
            { "view points (type 0)", "use points (type 1)", "exit app (type 2)" };
        static string studentNumber = "2011-00066-BN-0";
        static int points = 50;
        static void Main(string[] args)
        {
            Console.WriteLine("PUP-Points (Student) <press any key to continue>");
            Console.ReadKey();

            if (ValidateStudentNumber())
            {
                ProcessActionsForStudents();
            }
            else
            {
                Console.WriteLine("Sorry you enter an incorrect password! Application will exit.");
            }
        }

        private static void ProcessActionsForStudents()
        {
            for (int useraction = GetUserAction();
                 useraction != actions.IndexOf("exit app (type 2)");
                 useraction = GetUserAction())
            {
                switch (useraction)
                {
                    case 0:
                        Console.WriteLine(GetCurrentPoints());
                        break;
                    case 1:
                        UsePoints();
                        Console.WriteLine(GetCurrentPoints());
                        break;
                    default:
                        Console.WriteLine("Invalid! Try again.");
                        break;
                }
                Console.WriteLine();
            }
            Console.WriteLine("Application exiting...");
            Console.ReadKey();
        }

        static bool ValidateStudentNumber()
        {
            Console.Write("Please enter your Student Number: ");
            var userInput = Console.ReadLine();

            return userInput.Equals(studentNumber) ? true : false; //ternary operators
        }

        static string GetCurrentPoints()
        {
            return $"Total points as of {DateTime.Now}: {points}";
        }

        static void UsePoints()
        {
            Console.Write("How many points do you want to use? ");
            var pointsToUse = Convert.ToInt32(Console.ReadLine());

            if (pointsToUse <= points)
            {
                points -= pointsToUse;
                Console.WriteLine($"Successfully used {pointsToUse} points. ");
            }
            else
            {
                Console.WriteLine($"Insufficient balance. Please try again.");
                Console.WriteLine(GetCurrentPoints());
                UsePoints();
            }
        }

        static int GetUserAction()
        {
            ShowOptions();
            Console.Write("ACTION: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static void ShowOptions()
        {
            Console.WriteLine("Choose any of the following options. ");

            foreach (var action in actions)
            {
                Console.WriteLine(action);
            }
        }
    }
}
