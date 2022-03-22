using System.Text.Json;
using TT.dtoContract;

namespace TT.IO.JSON;

public class JSONConflictsReader : Text.TextReader, IConflictsReader
{
    public JSONConflictsReader(string path) : base(path) { }

    public List<Conflict> Read() => JsonSerializer.Deserialize<List<Conflict>>(ReadText());
}
