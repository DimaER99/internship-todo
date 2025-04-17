namespace Student.Todo
{
    /// <summary>
    /// Задача
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Заголовок задачи
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }

        public Task(string title, string description)
        {
            this.Title = title;
            this.Description = description;
        }

        /// <summary>
        /// Используем интерполяцию строк для вывода информации об объектах
        /// </summary>
        /// <returns>Строку, содержащую заголовок и описание задачи</returns>
        public override string ToString()
        {
            return $"Заголовок: {Title} \nОписание: {Description}";
        }
    }
}
