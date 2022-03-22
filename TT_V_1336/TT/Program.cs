using TT.IO.JSON;

namespace TT;

public class Program
{
    private static JSONDevicesReader reader;
    private static JSONConflictsWriter writer;

    public static void Main(string[] args)
    {
        (string inputPath, string outputPath) = GetPath(args);

        reader = new JSONDevicesReader(inputPath);
        writer = new JSONConflictsWriter(outputPath);

        writer.Write(ConflictsChecker.Check(reader.Read()));
    }

    private static (string inputPath, string outputPath) GetPath(string[] args)
    {
        (string inputPath, string outputPath) = (string.Empty, string.Empty);

        if (args.Length > 2)
        {
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-InputP":
                        if (i + 1 < args.Length)
                            inputPath = args[i + 1];
                        break;
                    case "-OutputP":
                        if (i + 1 < args.Length)
                            outputPath = args[++i];
                        break;
                    default:
                        break;
                }
            }
        }

        if (inputPath == string.Empty)
        {
            Console.Write("Input Path:\t");
            inputPath = Console.ReadLine();
        }

        if (outputPath == string.Empty)
        {
            Console.Write("\nOutput Path:\t");
            outputPath = Console.ReadLine();
        }

        return (inputPath, outputPath);
    }
}