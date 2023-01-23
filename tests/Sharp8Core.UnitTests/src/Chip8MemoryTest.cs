namespace Sharp8Core.UnitTests
{
    public class Chip8MemoryTest
    {
        [Fact]
        public void WithLoadRom_ShouldStoreItsBytesInCorrectAddress()
        {
            var startingRomAddress = 0x200;
            var romBytes = new byte[] { 0x12, 0x34, 0x56, 0x78 };
            var memory = new Chip8Memory();

            memory.LoadRom(romBytes);

            Assert.Equal(
                romBytes[0],
                memory.GetByteAtAddress(startingRomAddress)
            );
            Assert.Equal(
                romBytes[1],
                memory.GetByteAtAddress(startingRomAddress + 1)
            );
            Assert.Equal(
                romBytes[2],
                memory.GetByteAtAddress(startingRomAddress + 2)
            );
            Assert.Equal(
                romBytes[3],
                memory.GetByteAtAddress(startingRomAddress + 3)
            );
        }
    }
}
