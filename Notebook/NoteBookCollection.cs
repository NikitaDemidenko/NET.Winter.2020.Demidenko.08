using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Notebook
{
    /// <summary>Storage of notes.</summary>
    /// <seealso cref="IEnumerable{Note}" />
    public class NoteBookCollection : IEnumerable<Note>
    {
        private static readonly NoteBookCollection Instance = new NoteBookCollection();

        /// <summary>Prevents a default instance of the <see cref="NoteBookCollection"/> class from being created.</summary>
        private NoteBookCollection()
        {
            this.Notes = new List<Note>(0);
        }

        /// <summary>Gets list of notes.</summary>
        /// <value>List of notes.</value>
        public List<Note> Notes { get; }

        /// <summary>Gets the NoteBook instance.</summary>
        /// <returns>Returns NoteBook instance.</returns>
        public static NoteBookCollection GetNoteBookInstance() => Instance;

        /// <summary>Returns an enumerator that iterates through the notebook.</summary>
        /// <returns>An enumerator that can be used to iterate through the notebook.</returns>
        public IEnumerator<Note> GetEnumerator()
        {
            return this.Notes.GetEnumerator();
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
