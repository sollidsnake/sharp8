using System.IO.Abstractions;
using Sharp8.Core.RomReader;

namespace Sharp8.Core.UnitTests;

public class Chip8RomReaderTest
{
    [Fact]
    public void WithRead_ShouldReturnItsContent()
    {
        var fileName = "path/to/file";
        var fileReaderMock = new Moq.Mock<IFileSystem>();
        var romReader = new Chip8RomReader(fileReaderMock.Object);
        var expected = new byte[] { 0x00, 0xE0, 0xA2, 0x2A };
        fileReaderMock
            .Setup(x => x.File.ReadAllBytes(fileName))
            .Returns(expected);

        var actual = romReader.Read(fileName);

        fileReaderMock.Verify(
            x => x.File.ReadAllBytes(fileName),
            Moq.Times.Once
        );
        Assert.Equal(expected, actual);
    }
}
