using System.Text;

namespace TT.IO.Text;

public class TextWriter
{
    private protected string path;

    public TextWriter(string path) => this.path = path;

    private protected void WriteText(string json)
    {
        using FileStream fstream = new(path, FileMode.OpenOrCreate);

        byte[] buffer = Encoding.Default.GetBytes(json);
        fstream.WriteAsync(buffer, 0, buffer.Length);
    }
}