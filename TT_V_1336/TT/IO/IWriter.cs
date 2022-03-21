using TT.dtoContract;

namespace TT.IO;
public interface IWriter
{
    public void Write(List<Conflict> conflicts, string path);
}
