using System;

namespace Student.SharpInstructions
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                ShowInfo();

                string insertValue = Console.ReadLine();

                CallOperatorByNumber(insertValue);

                Console.Clear();
            }
        }

        private static void ShowInfo()
        {
            Console.WriteLine("Для вызова выполняемой подпрограммы укажите ее номер и нажните Enter:");
            Console.WriteLine("1 - IF ELSE");
            Console.WriteLine("2 - WHILE");
            Console.WriteLine("3 - DO WHILE");
            Console.WriteLine("4 - FOR");
            Console.WriteLine("5 - FOREACH");
            Console.WriteLine("6 - SWITCH");
        }

        private static void CallOperatorByNumber(string numberOperator)
        {
            while (true)
            {
                switch (numberOperator)
                {
                    case "1":
                        {
                            OperatorIfElse();

                            break;
                        }
                    case "2":
                        {
                            OperatorWhile();

                            break;
                        }
                    case "3":
                        {
                            OperatorDoWhile();

                            break;
                        }
                    case "4":
                        {
                            OperatorFor();

                            break;
                        }
                    case "5":
                        {
                            OperatorFOREACH();

                            break;
                        }
                    case "6":
                        {
                            OperatorSwitch();

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Некорректный выбор номера");

                            break;
                        }
                }

                Console.WriteLine("Для повтора выполнения подпрограммы нажмите Enter, для возврата к списку подпрограмм нажмите Esc");

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        private static void OperatorIfElse()
        {
            Console.WriteLine("Сегодня дождливая погода?");

            string inputValue = Console.ReadLine().ToLower().Trim();

            if (inputValue == "да")
            {
                Console.WriteLine("Возьмите с собой зонт");

            }
            else if (inputValue == "нет")
            {
                Console.WriteLine("Можете не брать с собой зонт");
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите 'да' или 'нет'.");
            }
        }


        private static void OperatorWhile()
        {
            Console.WriteLine("Введите любое число до 10");
            int count = Convert.ToInt32(Console.ReadLine());
            while (count < 10)
            {
                count++;
                Console.WriteLine(count);
            }

        }


        private static void OperatorDoWhile()
        {
            string name;

            do
            {
                Console.Write("Введите имя: ->");
                name = Console.ReadLine();

                Console.WriteLine(name);
            } while (name == "");


        }


        private static void OperatorFor()
        {
            Console.WriteLine("Введите строку: ");
            string input = Console.ReadLine();

            int count = 0;

            for (int i = 1; i <= input.Length; i++)
            {
                count++;
            }
            Console.WriteLine("Количество символов в строке: " + count);
        }

        private static void OperatorFOREACH()

        {
            string[] fruits = { "Яблоко", "Арбуз", "Апельсин" };
            foreach (string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }
        }



        private static void OperatorSwitch()
        {
            Console.WriteLine("Введи номер месяца");
            string numberMonth = Console.ReadLine();
            switch (numberMonth)
            {
                case "1":
                    {
                        Console.WriteLine("Январь");

                        break;

                    }
                case "2":
                    {
                        Console.WriteLine("Февраль");

                        break;

                    }
                case "3":
                    {
                        Console.WriteLine("Март");

                        break;

                    }
                case "4":
                    {
                        Console.WriteLine("Апрель");

                        break;

                    }
                case "5":
                    {
                        Console.WriteLine("Май");

                        break;

                    }
                case "6":
                    {
                        Console.WriteLine("Июнь");

                        break;

                    }
                case "7":
                    {
                        Console.WriteLine("Июль");

                        break;

                    }
                case "8":
                    {
                        Console.WriteLine("Август");

                        break;

                    }
                case "9":
                    {
                        Console.WriteLine("Сентябрь");

                        break;

                    }
                case "10":
                    {
                        Console.WriteLine("Октябрь");

                        break;

                    }
                case "11":
                    {
                        Console.WriteLine("Ноябрь");

                        break;

                    }
                case "12":
                    {
                        Console.WriteLine("Декабрь");

                        break;

                    }
                default:
                    {
                        Console.WriteLine("Некорректный выбор номера месяца");
                        
                        break;

                    }
                    
            }
        }

    }
}
