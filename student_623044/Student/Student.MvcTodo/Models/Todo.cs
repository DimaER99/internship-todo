using System.ComponentModel.DataAnnotations;

namespace Student.MvcTodo.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Display(Name = "Название задачи")]
        public string Title { get; set; }

        [Display(Name = "Описание задачи")]
        public string Description { get; set; }
    }
}