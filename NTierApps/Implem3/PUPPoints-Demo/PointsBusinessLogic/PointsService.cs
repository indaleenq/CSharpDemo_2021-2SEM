using PointsCommon;
using PointsDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsBusinessLogic
{
    public class PointsService
    {

        static public StudentPoints GetStudentPoints(string studentNumber)
        {
            var points = SqlData.GetPointsByStudent(studentNumber);
            return new StudentPoints { StudentNumber = studentNumber, Points = points };
        }

        static public List<StudentPoints> GetAllStudentPoints()
        {
            return SqlData.GetAllPoints();
        }

        static public bool UsePoints(UserRole userrole, string studentNumber, double pointToUse)
        {
            var availablePoints = GetStudentPoints(studentNumber).Points;

            if (availablePoints >= pointToUse && userrole == UserRole.Student)
            {
                return SqlData.UpdateStudentPoints(studentNumber, (availablePoints - pointToUse)) > 0 ? true : false;
            }
            else
            {
                return false;
            }
        }

        static public bool AddPoints(UserRole userrole, string studentNumber, double points)
        {
            var availablePoints = GetStudentPoints(studentNumber).Points;
            if (points > 0 && userrole == UserRole.Faculty)
            {
                return SqlData.UpdateStudentPoints(studentNumber, (points + availablePoints)) > 0 ? true : false;
            }
            else
            {
                return false;
            }
        }

        static public bool IfStudentExists(string studentNumber)
        {
            var isFound = false;
            var allStudentPoints = GetAllStudentPoints();
            foreach (var students in allStudentPoints)
            {
                if (students.StudentNumber.Equals(studentNumber))
                {
                    isFound = true;
                    break;
                }
            }
            return isFound; 
        }
    }
}
