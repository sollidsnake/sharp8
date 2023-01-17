using System.IO.Abstractions;

namespace Sharp8Core.RomReader;

public class Chip8RomReader
{
    private readonly IFileSystem _fileSystem;
    private readonly HexInstructions _hexInstructions;

    public Chip8RomReader(
        HexInstructions hexInstructions,
        IFileSystem fileSystem
    )
    {
        _fileSystem = fileSystem;
        _hexInstructions = hexInstructions;
    }

    public HexInstructions Read(string filename)
    {
        Console.WriteLine(filename);
        FileSystemStream stream = _fileSystem.File.OpenRead(filename);

        return _hexInstructions.LoadInstructions(ConvertToHex(stream));
    }

    protected string ConvertToHex(FileSystemStream stream)
    {
        byte[] buffer = new byte[stream.Length];
        stream.Read(buffer, 0, buffer.Length);
        return BitConverter.ToString(buffer);
    }
}
