#region System_lib
using System.Text;
using System.Text.Json;
#endregion

#region project_lib
using TT.dtoContract;
#endregion

namespace TT.IO;

public class JSONWriter : IWriter
{
    public void Write(List<Conflict> conflicts, string path) => WriteJSON(JsonSerializer.Serialize(conflicts), path);

    private static void WriteJSON(string json, string path)
    {
        using FileStream fstream = new(path, FileMode.OpenOrCreate);

        byte[] buffer = Encoding.Default.GetBytes(json);
        fstream.WriteAsync(buffer, 0, buffer.Length);
    }
}
