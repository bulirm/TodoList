using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Models
{
    public class Notes
    {
        private List<Note> notes;

        public IEnumerable<Note> All
        {
            get { return notes; }
        }
        
        public void Add(Note note)
        {
            notes.Add(note);
        }
    }
}
