using System.Text;

namespace TT.IO.Text;

public class TextReader
{
    private protected string path;

    public TextReader(string path) => this.path = path;

    private protected string ReadText()
    {
        using FileStream fstream = File.OpenRead(path);

        byte[] buffer = new byte[fstream.Length];
        fstream.Read(buffer, 0, buffer.Length);

        string temp = Encoding.Default.GetString(buffer);

        return temp;
    }
}