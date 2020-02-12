using System;
using System.Collections.Generic;
using System.Text;
using Notebook;

namespace NotebookConsole
{
    public class RenderOneNote : IView
    {
        private readonly NoteBookService noteBookService = NoteBookService.GetNoteBookServiceInstance();

        public int Number { get; set; }
        public void Render()
        {
            Console.WriteLine(this.noteBookService.GetNote(Number));
        }
    }
}
