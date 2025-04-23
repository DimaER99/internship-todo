using System.Data;

namespace Student.Todo.Data
{
    public interface ITaskService
    {
        /// <summary>
        /// Добавить задачу
        /// </summary>
        /// <param name="task">Задача</param>
        void AddTaskInDataBase(Task task);

        /// <summary>
        /// Получить задачи
        /// </summary>
        /// <returns>Задачи</returns>
        DataSet GetTasksFromDataBase();

        /// <summary>
        /// Удаление задача
        /// </summary>
        /// <param name="idTaskDelete">Ид задачи</param>
        void DeleteTaskFromId(int idTaskDelete);

        /// <summary>
        /// Изменить задачу
        /// </summary>
        /// <param name="idChangeTask">Ид задачи</param>
        /// <param name="changeTitle">Изменить заголовок</param>
        /// <param name="changeDescription">Изменить описание</param>
        void ChangeTaskFromId(int idChangeTask, string changeTitle, string changeDescription);
    }
}
