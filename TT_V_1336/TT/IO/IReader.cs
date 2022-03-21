using TT.dtoContract;

namespace TT.IO;

public interface IReader
{
    public List<DeviceInfo> Read(string path);
}
