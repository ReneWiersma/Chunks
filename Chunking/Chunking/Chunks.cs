using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ReneWiersma.Chunking
{
    public class Chunks<T> : IEnumerable<IEnumerable<T>>
    {
        readonly IEnumerable<T> items;
        readonly int chunkSize;
        readonly int numberOfChunks;

        public Chunks(IEnumerable<T> items, int chunkSize)
        {
            if (items == null)
                throw new ArgumentNullException("Items may not be null");

            if (chunkSize <= 0)
                throw new ArgumentOutOfRangeException("Chunk size should be greater than zero");

            this.items = items;
            this.chunkSize = chunkSize;

            numberOfChunks = (items.Count() + chunkSize - 1) / chunkSize;
        }

        public IEnumerator<IEnumerable<T>> GetEnumerator() => GetChunks().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerable<IEnumerable<T>> GetChunks()
        {
            for (int i = 0; i < numberOfChunks; i++)
                yield return items.Skip(i * chunkSize).Take(chunkSize);
        }
    }
}
