using System.Text.Json;
using TT.dtoContract;

namespace TT.IO.JSON;

public class JSONConflictsWriter : Text.TextWriter, IConflictsWriter
{
    public JSONConflictsWriter(string path) : base(path) { }

    public void Write(List<Conflict> devices) => WriteText(JsonSerializer.Serialize(devices));
}
