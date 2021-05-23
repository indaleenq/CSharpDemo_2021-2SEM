using PointsBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsStudentView
{
    class Program
    {
        static List<string> actions = new List<string>()
            { "view points (type 0)", "use points (type 1)", "exit app (type 2)" };
        static User studentUser;

        static PointsService.PointsServiceSoapClient _pointsService;
        static void Main(string[] args)
        {
            Console.WriteLine("PUP-Points (Student) <press any key to continue>");
            Console.ReadKey();

            _pointsService = new PointsService.PointsServiceSoapClient();

            studentUser = new User("ip.quinsayas@iskolarngbayan.pup.edu.ph", "2011-00066-BN-0");
            
            //if (studentUser.Login())
            if (_pointsService.Login(studentUser.UserId, studentUser.EmailAddress))
            {
                ProcessActionsForStudents();
            }
            else
            {
                Console.WriteLine("Sorry you don't have access! Application will exit.");
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
                        var currentPoints = GetCurrentPoints();
                        Console.WriteLine($"Total points as of {DateTime.Now}: {currentPoints}");
                        break;
                    case 1:
                        var usedPoints = UsePoints();
                        Console.WriteLine($"Successfully used {usedPoints} points. ");
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

        static double GetCurrentPoints()
        {
            //return PointsBusinessLogic.PointsService.GetStudentPoints(studentUser.UserId).Points;
            return _pointsService.GetStudentPoints(studentUser.UserId).Points;
        }

        static double UsePoints()
        {
            Console.Write("How many points do you want to use? ");
            var pointsToUse = Convert.ToInt32(Console.ReadLine());
            var currentPoints = GetCurrentPoints();

            if (pointsToUse <= currentPoints)
            {
                //return PointsBusinessLogic.PointsService.UsePoints(studentUser.UserRole, studentUser.UserId, pointsToUse)
                //        ? pointsToUse : 0;

                return _pointsService.UsePoints(studentUser.UserRole.ToString(), studentUser.UserId, pointsToUse)
                    ? pointsToUse : 0;
            }
            else
            {
                Console.WriteLine($"Insufficient balance. Please try again.");
                Console.WriteLine($"Available points: {currentPoints}");
                return UsePoints();
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
