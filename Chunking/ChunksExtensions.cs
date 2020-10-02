using System.Collections.Generic;

namespace ReneWiersma.Chunking
{
    public static class ChunksExtensions
    {
        public static IEnumerable<IEnumerable<T>> ToChunks<T>(this IEnumerable<T> items, int chunkSize) => new Chunks<T>(items, chunkSize);
    }
}
