using System;
using NUnit.Framework;
using Notebook;

namespace Notebook.Tests
{
    public class NoteTests
    {
        Note firstNote = new Note("Abc", "One Two Three");
        Note secondNote = new Note("Qwe", "one two three");
        Note thirdNote = new Note("fga", "onetwothree");
        Note fourthNote = new Note("FGA", "wqert");

        [Test]
        public void EqualsTest_ReturnedTrue() => Assert.That(thirdNote.Equals(fourthNote));

        [Test]
        public void EqualsTest_ReturnedFalse() => Assert.That(!firstNote.Equals(secondNote));

        [Test]
        public void GetHashCodeTest_ReturnedTrue() => Assert.That(thirdNote.GetHashCode() == fourthNote.GetHashCode());

        [Test]
        public void GetHashCodeTest_ReturnedFalse() => Assert.That(secondNote.GetHashCode() != firstNote.GetHashCode());
    }
}
