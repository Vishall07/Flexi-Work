using MySql.Data.MySqlClient;

namespace Flexi_Work.DataBaseManager
{
    public class EmployeeRegistrationDB
    {
        private readonly string _connectionString = "server=localhost;user=root;password=abcd1234;database=rdms_class";

        public string RegisterEmployeeInfoDB(EmployeeInfo employeeInfo)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Employees (EmployeeId, EmployeeName, EmployeePhoneNumber, EmployeeEmailId, Password) 
                                    VALUES (@id, @name, @phone, @email, @password)";

                cmd.Parameters.AddWithValue("@id", employeeInfo.EmployeeId);
                cmd.Parameters.AddWithValue("@name", employeeInfo.EmployeeName);
                cmd.Parameters.AddWithValue("@phone", employeeInfo.EmployeePhoneNumber);
                cmd.Parameters.AddWithValue("@email", employeeInfo.EmployeeEmailId);
                cmd.Parameters.AddWithValue("@password", employeeInfo.Password);

                cmd.ExecuteNonQuery();
            }

            return "SAVED";
        }
    }
}
