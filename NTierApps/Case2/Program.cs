using System;
using System.Collections.Generic;
using DataLayer;

namespace Scratch
{
    class Program
    {
        static List<string> actions = new List<string>() 
            { "view points (type 0)", "use points (type 1)", "exit app (type 2)" };
        static int points = 50;
        static void Main(string[] args)
        {
            Console.WriteLine("PUP-Points (Student) <press any key to continue>");
            Console.ReadKey();
            for (int useraction = GetUserAction(); 
                 useraction != actions.IndexOf("exit app (type 2)"); 
                 useraction = GetUserAction())
            {
                switch (useraction)
                {
                    case 0:
                        //Console.WriteLine(GetCurrentPoints());
                        Console.WriteLine(GetCurrentPointsInJson());
                        break;
                    case 1:
                        UsePoints(JsonData.GetPointsInJson());
                        //Console.WriteLine(GetCurrentPoints());
                        Console.WriteLine(GetCurrentPointsInJson());
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

        static string GetCurrentPoints()
        {
            return $"Total points as of {DateTime.Now}: {points}";
        }

        static string GetCurrentPointsInJson()
        {
            var points = JsonData.GetPointsInJson();
            return $"Total points as of {DateTime.Now}: {points}";
        }

        static int UsePoints(int points)
        {
            Console.Write("How many points do you want to use? ");
            var pointsToUse = Convert.ToInt32(Console.ReadLine());
            var remainingPoints = points;
            if (pointsToUse <= points)
            {
                //remainingPoints = points - pointsToUse;
                JsonData.UsePointsInJson(pointsToUse);
                Console.WriteLine($"Successfully used {pointsToUse}. ");
                return remainingPoints;
            }
            else
            {
                Console.WriteLine($"Insufficient balance. Please try again.");
                Console.WriteLine(GetCurrentPointsInJson());
                return UsePoints(remainingPoints);
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
