using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text;

using TodoList.Models;

namespace TodoList.Models
{
    /// <summary>
    /// Notes database class provides access to database and manages operation with database.
    /// </summary>
    class NotesDB
    {
        private SQLiteAsyncConnection database;

        public NotesDB()
        {
            database = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
            database.CreateTableAsync<Note>().Wait();
        }
        ~NotesDB()
        {
            database.CloseAsync().Wait();
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return database.Table<Note>().ToListAsync();
        }

        public Task<List<Note>> GetNotesDoneAsync()
        {
            return database.QueryAsync<Note>("SELECT * FROM [Note] WHERE [Done] = 1");
        }

        public Task<List<Note>> GetNotesNotDoneAsync()
        {
            return database.QueryAsync<Note>("SELECT * FROM [Note] WHERE [Done] = 0");
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.ID != 0)
            {
                return database.UpdateAsync(note);
            }
            else
            {
                return database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return database.DeleteAsync<Note>(note.ID);
        }
    }
}
