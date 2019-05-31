using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Models
{
    public class Note
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public Note(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
