using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Models
{
    /// <summary>
    /// Note model class which stores data about single note.
    /// </summary>
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Done { get; set; }

    }
}
