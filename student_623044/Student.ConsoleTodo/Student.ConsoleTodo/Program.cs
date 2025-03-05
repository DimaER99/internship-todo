using System;
using System.Collections.Generic;

namespace Student.ConsoleTodo
{
    class Task
    {
        public string TitleTask { get; set; }
        public string DescriptionTask { get; set; }

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

        private string GetTitleTask()
        {
            Console.WriteLine("Введите заголовок задачи. По завершению ввода нажмите Enter: ");
            return Console.ReadLine();
        }

        private string GetTaskDescription()
        {
            Console.WriteLine("Введите описание задачи: ");
            return Console.ReadLine();
        }

        public override string ToString()
        {
            return $"Заголовок: {TitleTask} \nОписание: {DescriptionTask}";
        }
    }

    class Program
    {
        private static List<Task> TaskList { get; set; } = new List<Task>();

        static void Main(string[] args)
        {                 
            
            while (true)
            {
                ShowInfo();

                string insertValue = Console.ReadLine();
                int numberTaskInt;

                if (int.TryParse(insertValue, out numberTaskInt))
                {
                    CallTaskByNumber(numberTaskInt);
                }
                else
                {
                    Console.WriteLine("Ошибка: Введите номер для вызова программы");
                    return;
                }
            }
        }

        private static void CallTaskByNumber(int numberTask)
        {
            Console.WriteLine();
            Console.Clear();

            switch (numberTask)
            {
                case 1:
                    Console.WriteLine("1 - Посмотреть список задач");
                    ViewTaskList();
                    break;

                case 2:
                    Console.WriteLine("2 - Добавить задачу");
                    Task task = new Task().AddTask();
                    TaskList.Add(task);
                    break;

                default:
                    Console.WriteLine("Некорректный выбор номера");
                    break;
            }
        }

        private static void ShowInfo()
        {
            Console.WriteLine("Для вызова выполняемой подпрограммы укажите ее номер и нажмите Enter: ");
            Console.WriteLine("1 - Посмотреть список задач");
            Console.WriteLine("2 - Добавить задачу");
        }

        public static void ViewTaskList()
        {
            Console.WriteLine("Список задач:");
            foreach (var task in TaskList)
            {
                Console.WriteLine(task);
            }
        }       
    }
}
