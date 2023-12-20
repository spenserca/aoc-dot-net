using System.IO;
using System.Reflection;

namespace AoC.UnitTests;

public class FileReader
{
    public static string[] ReadAllLines(string dataFilePath)
    {
        var filePath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            dataFilePath
        );
        return File.ReadAllLines(filePath);
    }
}
