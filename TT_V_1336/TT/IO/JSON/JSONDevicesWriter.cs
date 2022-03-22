using System.Text.Json;
using TT.dtoContract;

namespace TT.IO.JSON;

public class JSONDevicesWriter : Text.TextWriter, IDevicesWriter
{
    public JSONDevicesWriter(string path) : base(path) { }

    public void Write(List<DeviceInfo> devices) => WriteText(JsonSerializer.Serialize(devices));
}
