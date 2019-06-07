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

        private static List<Note> done;
        private static List<Note> undone;

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
        }

        public static async Task Destroy()
        {
            List<Note> all = new List<Note>();
            all.AddRange(done);
            all.AddRange(undone);

            await notesDB.SaveAllNotesAsync(all);
        }
    } 
}
