using System;
using System.Data.SqlClient;

namespace DataLayer
{
    public class SqlData
    {
        static string connectionString
        //= "Data Source =.; Initial Catalog = PUPPoints;User Id=sa;Password=indaleenq727!; Integrated Security = True;";
        = "Server=tcp:137.116.161.191,1433;Database=PUPPoints;User Id=sa;Password=integbsit2!";
        static SqlConnection sqlConnection = new SqlConnection(connectionString);

        static public bool ValidateIfStudentExists(string studentNumber)
        {
            var selectStatement = "SELECT StudentNumber FROM StudentPoints WHERE StudentNumber = @StudentNumber";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var isExists = reader.Read();
            sqlConnection.Close();
            return isExists;
        }

        static public int GetPointsByStudent(string studentNumber)
        {
            var selectStatement = "SELECT Points FROM StudentPoints WHERE StudentNumber = @StudentNumber";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            var points = 0;
            if (reader.Read())
            {
                points = Convert.ToInt32(reader["Points"]);
            }
            sqlConnection.Close();
            return points;
        }

        static public void UpdateStudentPoints(string studentNumber, int points)
        {
            var updateStatement = $"UPDATE StudentPoints SET Points = @Points WHERE StudentNumber = @StudentNumber";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@Points", points);
            updateCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);
            sqlConnection.Open();
            updateCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
