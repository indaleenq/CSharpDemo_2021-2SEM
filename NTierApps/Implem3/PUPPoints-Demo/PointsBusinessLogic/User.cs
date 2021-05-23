using PointsDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsBusinessLogic
{
    [Serializable]
    public class User
    {
        public User()
        {

        }
        public User(string emailaddress, string userid)
        {
            this.UserId = userid;
            this.EmailAddress = emailaddress;
        }
        public string UserId { get; set; }
        public string EmailAddress { get; set; }
        public UserRole UserRole { get; set; }

        public bool Login()
        {
            var userRole = SqlData.ValidateUser(this.UserId, this.EmailAddress);
            if (!string.IsNullOrEmpty(userRole))
            {
                this.UserRole = (UserRole)Enum.Parse(typeof(UserRole), userRole);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    [Serializable]
    public enum UserRole
    {
        Student,
        Faculty,
        Admin
    }
}
