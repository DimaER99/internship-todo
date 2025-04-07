using Student.Todo;
using System;
using System.Collections.Generic;

namespace Student.ConsoleTodo
{
    public class Program
    {
        /// <summary>
        /// Список задач для хранения и управлением объектами типа Task
        /// </summary>
        public static List<Task> TaskList { get; set; } = new List<Task>();

        public static void Main(string[] args)
        {                 
            while (true)
            {
                Console.Clear();
                ShowInfo();

                string insertValue = Console.ReadLine();
                int numberTaskInt;
                Console.Clear();
                if (int.TryParse(insertValue, out numberTaskInt))
                {
                    CallTaskByNumber(numberTaskInt);
                }

                else
                {
                    Console.WriteLine("Ошибка: Введите номер для вызова программы");
                }

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Для повторного ввода операции нажмите Enter, для завершения приложения Esc.");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        return;
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Вызов задачи по номеру
        /// </summary>
        /// <param name="numberTask">Номер задачи</param>
        public static void CallTaskByNumber(int numberTask)
        { 
            switch (numberTask)
            {
                case 1:
                    Console.WriteLine("1 - Посмотреть список задач");
                    ViewTaskList();

                    Exit();

                    break;

                case 2:
                    Console.WriteLine("2 - Добавить задачу");

                    Console.WriteLine("Введите заголовок");
                    string title = Console.ReadLine();
                    Console.WriteLine("Введите описание");
                    string description = Console.ReadLine();

                    Task task = new Task(title, description);

                    TaskList.Add(task);     
                    break;

                default:
                    Console.WriteLine("Некорректный выбор номера");
                    break;
            }
        }

        /// <summary>
        /// Показать информацию
        /// </summary>
        public static void ShowInfo()
        {
            Console.WriteLine("Для вызова выполняемой подпрограммы укажите ее номер и нажмите Enter: ");
            Console.WriteLine("\r\n1 - Посмотреть список задач");
            Console.WriteLine("2 - Добавить задачу");

        }

        /// <summary>
        /// Показать список задач
        /// </summary>
        public static void ViewTaskList()
        {
            int number = 0; 
            Console.WriteLine("\r\nСписок задач:");
            foreach (var task in TaskList)
            {
                number += 1;
                Console.WriteLine($"\r\nЗадача номер: '{number}'");
                Console.WriteLine("Заголовок: " + task.Title);
                Console.WriteLine("Описание:  " + task.Description);
            }
        }

        /// <summary>
        /// Выход в список подпрограмм
        /// </summary>
        public static void Exit()
        {
            string str = "\r\nДля возврата к списку подпрограмм нажмите Esc: ";
            Console.WriteLine(str);

            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.WriteLine("\r\nОшибка. Для возврата к списку подпрограмм нажмите Esc: ");
                return;
            }
        }
    }
}