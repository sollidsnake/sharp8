using System.IO.Abstractions;

namespace Sharp8Core.RomReader;

public class Chip8RomReader
{
    private readonly IFileSystem _fileSystem;

    public Chip8RomReader(
        IFileSystem fileSystem
    )
    {
        _fileSystem = fileSystem;
    }

    public string Read(string filename)
    {
        Console.WriteLine(filename);
        FileSystemStream stream = _fileSystem.File.OpenRead("/home/jesse/code/learn/sharp-8/tests/assets/ibmlogo.ch8");

        return ConvertToHex(stream);
    }

    protected string ConvertToHex(FileSystemStream stream)
    {
        byte[] buffer = new byte[stream.Length];
        stream.Read(buffer, 0, buffer.Length);
        return BitConverter.ToString(buffer);
    }
}
