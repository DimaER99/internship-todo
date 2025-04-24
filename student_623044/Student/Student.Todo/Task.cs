using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Todo
{
    /// <summary>
    /// Задача
    /// </summary>

    [Table("Todo")]
    public class Task
    {
        /// <summary>
        /// Id задачи
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Заголовок задачи
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Конструтор для работы EF
        /// </summary>
        public Task()
        {

        }

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
