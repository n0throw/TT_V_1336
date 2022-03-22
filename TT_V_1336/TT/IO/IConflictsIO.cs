using TT.dtoContract;

namespace TT.IO;

public interface IConflictsReader
{
    public List<Conflict> Read();
}

public interface IConflictsWriter
{
    public void Write(List<Conflict> conflicts);
}