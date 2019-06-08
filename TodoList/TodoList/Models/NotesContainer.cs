using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

using SQLite;

namespace TodoList.Models
{
    /// <summary>
    /// Class holds data about notes in database.
    /// </summary>
    public static class NotesContainer
    {
        private static NotesDB notesDB;

        public static event EventHandler OnChanged;

        /// <summary>
        /// Store done/undone todo items (notes).
        /// </summary>
        private static List<Note> done = new List<Note>();
        private static List<Note> undone = new List<Note>();

        public static IEnumerable<Note> Done
        {
            get
            {
                return done;
            }
        }

        public static IEnumerable<Note> DoneOrdered
        {
            get
            {
                return done.Select(note => note).Reverse();
            }
        }

        public static IEnumerable<Note> Undone
        {
            get
            {
                return undone;
            }
        }

        /// <summary>
        /// Returns ordered undone notes by deadline date.
        /// Priority:
        /// 1. early date
        /// 2. late date
        /// 3. no date
        /// </summary>
        public static IEnumerable<Note> UndoneOrdered
        {
            get
            {
                IEnumerable<Note> notes = undone.OrderBy(note => note.Deadline).Where(note => note.Deadline != null);
                notes = notes.Select(note => note).Concat(undone.Where(note => note.Deadline == null));
                return notes;
            }
        }

        public static async Task Initialize()
        {
            //Create access to Database
            notesDB = new NotesDB();

            //fetch data from database
            done = await notesDB.GetNotesDoneAsync();
            undone = await notesDB.GetNotesNotDoneAsync();

            Change();
        }

        /// <summary>
        /// Save asynchronously data to database and add to undone list.
        /// </summary>
        /// <param name="note">Note model object</param>
        public static void AddNote(Note note)
        {
            Task.Run(async () =>
            {
                await notesDB.SaveNoteAsync(note);
            });
            undone.Add(note);
            Change();
        }
        /// <summary>
        /// Removes asynchronously data from db and removes from list according to Done property.
        /// </summary>
        /// <param name="note">Note model object</param>
        public static void DeleteNote(Note note)
        {
            Task.Run(async () =>
            {
                await notesDB.DeleteNoteAsync(note);
            });
            if (note.Done)
            {
                done.Remove(note);
            }
            else
            {
                undone.Remove(note);
            }
            Change();
        }

        /// <summary>
        /// Change note's Done property, removes from undones to dones
        /// and update in database asynchronously.
        /// </summary>
        /// <param name="note">Note model object</param>
        public static void MarkAsDone(Note note)
        {
            if (!note.Done)
            {
                undone.Remove(note);
                note.Done = true;
                done.Add(note);
                Task.Run(async () =>
                {
                    await notesDB.SaveNoteAsync(note);
                });
                Change();
            }
        }

        /// <summary>
        /// Raise the event when data changed.
        /// </summary>
        private static void Change()
        {
            OnChanged?.Invoke(new object(), new EventArgs());
        }
    } 
}
