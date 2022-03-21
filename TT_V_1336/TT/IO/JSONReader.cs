#region System_lib
using System.Text;
using System.Text.Json;
#endregion

#region project_lib
using TT.dtoContract;
#endregion

namespace TT.IO;

public class JSONReader : IReader
{
    public List<DeviceInfo> Read(string path) => JsonSerializer.Deserialize<List<DeviceInfo>>(GetJSON(path));

    private static string GetJSON(string path)
    {
        using FileStream fstream = File.OpenRead(path);

        byte[] buffer = new byte[fstream.Length];
        fstream.Read(buffer, 0, buffer.Length);

        string temp = Encoding.Default.GetString(buffer);

        return temp;
    }
}
