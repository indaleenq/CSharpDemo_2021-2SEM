using PointsBusinessLogic;
using PointsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PUPPointsWebService
{
    /// <summary>
    /// Summary description for PointsService
    /// </summary>
    [WebService(Namespace = "http://pointservice.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PointsService : System.Web.Services.WebService
    {

        [WebMethod]
        public bool Login(string userId, string emailAddress)
        {
            var user = new User(emailAddress, userId);
            return user.Login();
        }

        [WebMethod]
        public StudentPoints GetStudentPoints(string number)
        {
            return PointsBusinessLogic.PointsService.GetStudentPoints(number);
        }

        [WebMethod]
        public List<StudentPoints> GetAllStudentPoints()
        {
            return PointsBusinessLogic.PointsService.GetAllStudentPoints();
        }

        [WebMethod]
        public bool UsePoints(string userRole, string studentNumber, double points)
        {
            var role = (UserRole)Enum.Parse(typeof(UserRole), userRole);
            return PointsBusinessLogic.PointsService.UsePoints(role, studentNumber, points); ;
        }

        [WebMethod]
        public bool AddPoints(string userRole, string studentNumber, double points)
        {
            var role = (UserRole)Enum.Parse(typeof(UserRole), userRole);
            return PointsBusinessLogic.PointsService.AddPoints(role, studentNumber, points);
        }

        [WebMethod]
        public bool IfStudentExists(string studentNumber)
        {
            return PointsBusinessLogic.PointsService.IfStudentExists(studentNumber);
        }

    }
}
