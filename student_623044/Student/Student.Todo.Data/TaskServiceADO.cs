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

        /// <inheritdoc/>
        public void AddTaskInDataBase(Task task)
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

        /// <inheritdoc/>
        public DataSet GetTasksFromDataBase()
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

        /// <inheritdoc/>
        public void DeleteTaskFromId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                string query = "DELETE FROM Todo WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <inheritdoc/>
        public void ChangeTaskFromId(int id, string title, string description)
        {
            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                string query = "UPDATE Todo SET Title = @Title, Description = @Description WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
