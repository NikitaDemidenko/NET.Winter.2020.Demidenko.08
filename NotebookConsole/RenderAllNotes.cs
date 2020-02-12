using System;
using System.Collections.Generic;
using System.Text;
using Notebook;

namespace NotebookConsole
{
    public class RenderAllNotes : IView
    {
        private readonly NoteBookService noteBookService = NoteBookService.GetNoteBookServiceInstance();

        public void Render()
        {
            var notes = noteBookService.GetNotes();
            foreach (var note in notes)
            {
                Console.WriteLine(note);
            }
        }
    }
}
