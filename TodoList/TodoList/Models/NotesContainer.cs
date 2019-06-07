using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text;

using SQLite;

namespace TodoList.Models
{
    public static class NotesContainer
    {
        private static NotesDB notesDB;

        public static event EventHandler OnChanged;

        private static List<Note> done = new List<Note>();
        private static List<Note> undone = new List<Note>();

        public static IEnumerable<Note> Done
        {
            get
            {
                return done;
            }
        }

        public static IEnumerable<Note> Undone
        {
            get
            {
                return undone;
            }
        }
        
        public static async Task Initialize()
        {
            notesDB = new NotesDB();

            done = await notesDB.GetNotesDoneAsync();
            undone = await notesDB.GetNotesNotDoneAsync();

            Change();
        }
        
        public static void AddNote(Note note)
        {
            Task.Run(async () =>
            {
                await notesDB.SaveNoteAsync(note);
            });
            undone.Add(note);
            Change();
        }

        private static void Change()
        {
            OnChanged?.Invoke(new object(), new EventArgs());
        }
    } 
}
