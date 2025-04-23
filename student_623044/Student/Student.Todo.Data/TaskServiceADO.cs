using Microsoft.Data.SqlClient;
using System.Data;

namespace Student.Todo.Data
{
    public class TaskServiceADO : ITaskService
    {
        public readonly string connectionStrings;

        public TaskServiceADO(string connectionString)
        {
            connectionStrings = connectionString;
        }

        void ITaskService.AddTaskInDataBase(Task task)
        {
            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                 $"INSERT INTO [dbo].[Todo] (Title, Description) VALUES (@Title, @Description)", connection);
                command.Connection = connection;
                command.Parameters.AddWithValue("Title", task.Title);
                command.Parameters.AddWithValue("Description", task.Description);

                command.ExecuteNonQuery().ToString();
            }
        }

        DataSet ITaskService.GetTasksFromDataBase()
        {
            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                string query = "SELECT Id, Title, Description FROM Todo";
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
                {
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }

        void ITaskService.DeleteTaskFromId(int idTaskDelete)
        {
            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                string query = "DELETE FROM Todo WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idTaskDelete);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        void ITaskService.ChangeTaskFromId(int idChangeTask, string changeTitle, string changeDescription)
        {
            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                string query = "UPDATE Todo SET Title = @Title, Description = @Description WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@Title", changeTitle);
                    command.Parameters.AddWithValue("@Description", changeDescription);
                    command.Parameters.AddWithValue("@Id", idChangeTask);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
