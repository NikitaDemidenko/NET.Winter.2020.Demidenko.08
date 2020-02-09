using System;
using NUnit.Framework;
using Notebook;

namespace Notebook.Tests
{
    public class NoteBookServiceTests
    {
        private NoteBookService noteBookService = NoteBookService.GetNoteBookServiceInstance();

        [SetUp]
        public void Setup()
        {
            noteBookService.CreateNote("dasdsa", "ASdasdfdsf");
            noteBookService.CreateNote("sadas", "XZCXZCzxczx");
            noteBookService.CreateNote("dsadsa", "ASDASD");
        }

        [Test]
        public void CreateNote_ContentIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => noteBookService.CreateNote("sdadsa", null));

        [Test]
        public void EditNote_ContentIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => noteBookService.EditNote(2, "dsadsa", null));

        [Test]
        public void CreateNote_TitleIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => noteBookService.CreateNote(null, "ASDAS"));

        [Test]
        public void EditNote_TitleIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => noteBookService.EditNote(2, null, "ASDSAD"));

        [Test]
        public void EditNote_NumberIsNegative_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => noteBookService.EditNote(-2, "sadas", "ASDa"));

        [Test]
        public void EditNote_NumberIsOutOfRange_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => noteBookService.EditNote(32, "sadas", "asdas"));

        [Test]
        public void GetStatTest() => Assert.AreEqual(3, noteBookService.GetStat());
    }
}