using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.WindowsTodo
{
    public class Task 
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Task(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}

