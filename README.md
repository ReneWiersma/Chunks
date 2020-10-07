# Chunks

The Chunking extension divides an IEnumerable into equally sized chunks and allows you to iterate over them. 

This may be useful when, for example, sending a large of items to a webservice, or saving a large number of items to a database, which may otherwise result in time-outs.

Example of use:

```
var items = new List<string>();

// add a large number of items to list

foreach (var chunk in items.ToChunks(chunkSize: 250))
{
  // process chunk
}
```
