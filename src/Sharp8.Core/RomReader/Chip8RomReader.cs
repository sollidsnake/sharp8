using System.IO.Abstractions;

namespace Sharp8.Core.RomReader;

public class Chip8RomReader
{
    private readonly IFileSystem _fileSystem;

    public Chip8RomReader(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public byte[] Read(string filename)
    {
        return _fileSystem.File.ReadAllBytes(filename);
    }
}
