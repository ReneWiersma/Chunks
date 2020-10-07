# Chunks

The Chunking extension divides an IEnumerable into smaller chunks. 

This may be useful when, for example, sending a large of items to a webservice, or saving a large number of items to a database, which may otherwise result in time-outs.

## Installation

Available on [nuget](https://www.nuget.org/packages/ReneWiersma.Chunking/)

	PM> Install-Package ReneWiersma.Chunking

### Example of use

```csharp
var items = new List<string>();

// add a large number of items to list

foreach (var chunk in items.ToChunks(chunkSize: 250))
{
  // process chunk
}
```
