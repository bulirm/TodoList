using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text;

using TodoList.Models;

namespace TodoList.Models
{
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

        public async Task SaveAllNotesAsync(List<Note> notes)
        {
            await DeleteAllNotesAsync();
            await database.InsertAllAsync(notes);
        }

        private Task<int> DeleteAllNotesAsync()
        {
            return database.DeleteAllAsync<Note>();
        }
    }
}
