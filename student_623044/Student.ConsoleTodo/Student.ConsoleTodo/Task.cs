using System;

namespace Student.ConsoleTodo
{
    /// <summary>
    /// Задача
    /// </summary>
    class Task
    {
        /// <summary>
        /// Заголовок задачи
        /// </summary>
        public string TitleTask { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string DescriptionTask { get; set; }

        /// <summary>
        /// Добавление задачи
        /// </summary>
        /// <returns>Задачу</returns>
        public Task AddTask()
        {
            var taskTitle = GetTitleTask();
            var taskDescription = GetTaskDescription();

            return new Task
            {
                TitleTask = taskTitle,
                DescriptionTask = taskDescription
            };
        }

        /// <summary>
        /// Вводим заголовок задачи
        /// </summary>
        /// <returns>Заголовок задачи</returns>
        private string GetTitleTask()
        {
            while(true)
            {
                Console.WriteLine("Введите заголовок задачи. По завершению ввода нажмите Enter: ");
                return Console.ReadLine();
            }
        }

        /// <summary>
        /// Вводим описание задачи
        /// </summary>
        /// <returns>Описание задачи</returns>
        private static string GetTaskDescription()
        {
            Console.WriteLine("Введите описание задачи: ");
            return Console.ReadLine();

        }

        /// <summary>
        /// Используем интерполяцию строк для вывода информации об объектах
        /// </summary>
        /// <returns>Строку, содержащую заголовок и описание задачи</returns>
        public override string ToString()
        {
            return $"Заголовок: {TitleTask} \nОписание: {DescriptionTask}";
        }    
    }
}
