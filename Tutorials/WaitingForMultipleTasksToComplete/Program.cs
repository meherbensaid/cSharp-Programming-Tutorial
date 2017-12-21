using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaitingForMultipleTasksToComplete
{
    class Program
    {
        static private string GetConnectionString()
        {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file.
            return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Tutorials;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        static void Main(string[] args)
        {

            List<int> userIds = new List<int>();
            for(int i = 1; i < 18; i++)
            {
                userIds.Add(i);
            }

            var users= GetUsersAsync(userIds);

          
            for (int i = 0; i < 1000000; i++)
            {
                Console.WriteLine("waiting for Async Select from DB");
            }
        }



        public static async Task<IEnumerable<User>> GetUsersAsync(IEnumerable<int> userIds)
        {
            var getUserTasks = new List<Task<User>>();

            foreach (int userId in userIds)
            {
                getUserTasks.Add(GetUserAsync(userId));
            }

            return await Task.WhenAll(getUserTasks);
        }

        private static async Task<User> GetUserAsync(int Id)
        {
            var connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                SqlDataReader reader;
                User user;
                command.CommandText = "dbo.GetUserById";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters["@Id"].Value = Id;
                /// command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int).Value = 1);
                command.Connection = connection;

                user=await Task<User>.Factory.StartNew(() =>
                {
                    connection.Open();

                    reader = command.ExecuteReader();
                    reader.ReadAsync();
                    User userAsync = new User()
                    {
                        Id = reader["Id"].ToString(),
                        Name = reader["Name"].ToString(),
                        Age = reader["Age"].ToString()
                    };
                    return  userAsync;
                });

                return user;
            }

        }
    }
}

