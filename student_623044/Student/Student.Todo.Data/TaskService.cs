using Microsoft.Data.SqlClient;
using System.Data;

namespace Student.Todo.Data
{
    public class TaskService
    {
        public readonly string connectionStrings;

        public TaskService(string connectionString)
        {
            connectionStrings = connectionString;
        }

        /// <summary>
        /// Добавить задачу
        /// </summary>
        /// <param name="task">Задача</param>
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

        /// <summary>
        /// Получить задачи
        /// </summary>
        /// <returns>Задачи</returns>
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
        
        /// <summary>
        /// Удаление задача
        /// </summary>
        /// <param name="idTaskDelete">Ид задачи</param>
        public void DeleteTaskFromId(int idTaskDelete)
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

        /// <summary>
        /// Изменить задачу
        /// </summary>
        /// <param name="idChangeTask">Ид задачи</param>
        /// <param name="changeTitle">Изменить заголовок</param>
        /// <param name="changeDescription">Изменить описание</param>
        public void ChangeTaskFromId(int idChangeTask, string changeTitle, string changeDescription)
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
