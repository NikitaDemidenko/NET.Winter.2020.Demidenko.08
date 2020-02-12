using System;
using Notebook;

namespace NotebookConsole
{
    class Program
    {
        private static readonly NoteBookService noteBookService = NoteBookService.GetNoteBookServiceInstance();
        private static readonly RenderAllNotes renderAll = new RenderAllNotes();
        private static readonly RenderOneNote renderOne = new RenderOneNote()
        {
            Number = 2,
        };

        static void Main(string[] args)
        {
            noteBookService.CreateNote("123", "100 + 23 = 123");
            noteBookService.CreateNote("50", "100 - 50 = 50");
            renderOne.Render();
            Console.WriteLine();
            renderAll.Render();
        }
    }
}
