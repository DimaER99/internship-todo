using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <returns></returns>
        private static string GetTaskDescription()
        {
            Console.WriteLine("Введите описание задачи: ");
            return Console.ReadLine();

        }

        /// <summary>
        /// Используем интерполяцию строк для вывода информации об объектах
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Заголовок: {TitleTask} \nОписание: {DescriptionTask}";
        }    
    }
}
