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
        /// Удаление задачи
        /// </summary>
        /// <param name="id">Ид задачи</param>
        void DeleteTaskFromId(int id);

        /// <summary>
        /// Изменить задачу
        /// </summary>
        /// <param name="id">Ид задачи</param>
        /// <param name="title">Заголовок</param>
        /// <param name="description">Описание</param>
        void ChangeTaskFromId(int id, string title, string description);
    }
}
