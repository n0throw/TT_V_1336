using TT.dtoContract;

namespace TT.IO;

public interface IDevicesReader
{
    public List<DeviceInfo> Read();
}

public interface IDevicesWriter
{
    public void Write(List<DeviceInfo> devices);
}