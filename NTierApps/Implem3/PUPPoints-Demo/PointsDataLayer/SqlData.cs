using PointsCommon;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PointsDataLayer
{
    public class SqlData
    {
        static string connectionString
       //= "Data Source =.; Initial Catalog = PUPPoints;User Id=sa;Password=indaleenq727!; Integrated Security = True;";
        = "Server=tcp://,1433;Database=PUPPoints;User Id=sa;Password=indaleenq727!;";
        static SqlConnection sqlConnection = new SqlConnection(connectionString);

        static public string ValidateUser(string userid, string emailaddress)
        {
            var selectStatement = "SELECT UserRole FROM [PUPPoints].[dbo].[User] WHERE UserId = @UserId AND EmailAddress = @EmailAddress";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@UserId", userid);
            selectCommand.Parameters.AddWithValue("@EmailAddress", emailaddress);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var userRole = reader.Read() ? reader["UserRole"].ToString() : string.Empty;
            sqlConnection.Close();
            return userRole;
        }

        static public double GetPointsByStudent(string studentNumber)
        {
            var selectStatement = "SELECT Points FROM StudentPoints WHERE StudentNumber = @StudentNumber";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var points = reader.Read() ? Convert.ToInt32(reader["Points"]) : 0.0;
            sqlConnection.Close();
            return points;
        }

        static public List<StudentPoints> GetAllPoints()
        {
            var selectStatement = "SELECT StudentNumber, Points FROM StudentPoints";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var studentPoints = new List<StudentPoints>();

            while (reader.Read())
            {
                studentPoints.Add(new StudentPoints
                {
                    StudentNumber = reader["StudentNumber"].ToString(),
                    Points = Convert.ToDouble(reader["Points"])
                });
            }

            sqlConnection.Close();
            return studentPoints;
        }

        static public int UpdateStudentPoints(string studentNumber, double points)
        {
            var updateStatement = $"UPDATE StudentPoints SET Points = @Points WHERE StudentNumber = @StudentNumber";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@Points", points);
            updateCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);
            sqlConnection.Open();
            var result = updateCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return result;
        }
    }
}
