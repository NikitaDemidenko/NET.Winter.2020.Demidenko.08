using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Notebook
{
    /// <summary>Provides methods for interaction with notebook.</summary>
    public class NoteBookService
    {
        private static readonly NoteBookService Instance = new NoteBookService();
        private readonly NoteBookCollection noteBook;

        private NoteBookService()
        {
            this.noteBook = NoteBookCollection.GetNoteBookInstance();
        }

        /// <summary>Gets the NoteBookService instance.</summary>
        /// <returns>Returns NoteBookService instance.</returns>
        public static NoteBookService GetNoteBookServiceInstance() => Instance;

        /// <summary>Creates new note.</summary>
        /// <param name="title">Title of note.</param>
        /// <param name="content">Content of note.</param>
        /// <exception cref="ArgumentNullException">Thrown when content or title is null.</exception>
        public void CreateNote(string title, string content)
        {
            if (title is null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (content is null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            var note = new Note(title, content)
            {
                Number = this.noteBook.Notes.Count + 1,
            };
            this.noteBook.Notes.Add(note);
        }

        /// <summary>Edits note.</summary>
        /// <param name="number">Number of note.</param>
        /// <param name="title">Title of note.</param>
        /// <param name="content">Content of note.</param>
        /// <exception cref="ArgumentException">Thrown when given number is invalid.</exception>
        /// <exception cref="ArgumentNullException">Thrown when content or title is null.</exception>
        public void EditNote(int number, string title, string content)
        {
            if (number < 1 || number > this.GetStat())
            {
                throw new ArgumentException("Note with this number doesn't exist.");
            }

            if (title is null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (content is null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            foreach (var note in this.noteBook)
            {
                if (note.Number == number)
                {
                    note.Title = title;
                    note.Content = content;
                    note.TimeOfCreation = DateTime.Now;
                    break;
                }
            }
        }

        /// <summary>Gets the number of notes.</summary>
        /// <returns>Returns number of notes.</returns>
        public int GetStat() => this.noteBook.Notes.Count;

        /// <summary>Gets notes.</summary>
        /// <returns>Returns read-only collection of notes.</returns>
        public ReadOnlyCollection<Note> GetNotes() => new ReadOnlyCollection<Note>(this.noteBook.Notes);
    }
}
