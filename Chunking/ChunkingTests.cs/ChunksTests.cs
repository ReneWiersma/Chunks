using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReneWiersma.Chunking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChunkingTests
{
    [TestClass]
    public class ChunksTests
    {
        [DataTestMethod]
        [DataRow(0, 100, 0)]
        [DataRow(1, 100, 1)]
        [DataRow(99, 100, 1)]
        [DataRow(100, 100, 1)]
        [DataRow(101, 100, 2)]
        public void CorrectNumberOfChunks(int numberOfItems, int chunkSize, int expected)
        {
            var items = CreateItems(numberOfItems);

            var sut = new Chunks<string>(items, chunkSize);

            Assert.AreEqual(expected, sut.Count());
        }

        private static IEnumerable<string> CreateItems(int numberOfItems)
        {
            for (int i = 0; i < numberOfItems; i++)
                yield return i.ToString();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChunkSizeZeroNotAllowed()
        {
            var items = new List<string>();

            new Chunks<string>(items, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ItemsListNullNotAllowed()
        {
            new Chunks<string>(null, 100);
        }

        [TestMethod]
        public void ChunkSizeForSingleChunk()
        {
            var items = CreateItems(19);

            var sut = new Chunks<string>(items, chunkSize: 20).ToArray();

            Assert.AreEqual(19, sut[0].Count());
        }

        [TestMethod]
        public void ChunkSizeForMultipleChunks()
        {
            var items = CreateItems(21);

            var sut = new Chunks<string>(items, chunkSize: 20).ToArray();

            Assert.AreEqual(20, sut[0].Count());
            Assert.AreEqual(1, sut[1].Count());
        }

        [TestMethod]
        public void OriginalOrderIsPreserved()
        {
            var items = CreateItems(5);

            var sut = new Chunks<string>(items, chunkSize: 3).ToArray();

            Assert.AreEqual("0", sut[0].ToArray()[0]);
            Assert.AreEqual("1", sut[0].ToArray()[1]);
            Assert.AreEqual("2", sut[0].ToArray()[2]);
            Assert.AreEqual("3", sut[1].ToArray()[0]);
            Assert.AreEqual("4", sut[1].ToArray()[1]);
        }
    }
}
