using System.Text.Json;
using TT.dtoContract;

namespace TT.IO.JSON;

public class JSONDevicesReader : Text.TextReader, IDevicesReader
{
    public JSONDevicesReader(string path) : base(path) { }

    public List<DeviceInfo> Read() => JsonSerializer.Deserialize<List<DeviceInfo>>(ReadText());
}
