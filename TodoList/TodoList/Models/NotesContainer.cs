using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Models
{
    public class NotesContainer
    {
        private List<Note> notes;

        public IEnumerable<Note> Notes
        {
            get
            {
                return notes;
            }
        }

        public NotesContainer()
        {
            notes = new List<Note>()
            {
                new Note("title1", "description1"),
                new Note("title2", "description2"),
                new Note("title3", "description3")
            };
        }
    }
}
