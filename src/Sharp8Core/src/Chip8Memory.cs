namespace Sharp8Core;

public class Chip8Memory : IChip8Memory
{
    public int RomStartingAddress { get; } = 0x200;
    private const uint MemorySize = 4096;
    public byte[] Memory { get; } = new byte[MemorySize];
    public byte[] RomBytes { get; private set; } = default!;

    public int this[int address] => Memory[address];

    public Chip8Memory()
    {
        Memory = new byte[MemorySize];
    }

    public void LoadRom(byte[] rom)
    {
        RomBytes = rom;
        for (var i = 0x0; i < rom.Length; i += 0x1)
        {
            Memory[i + RomStartingAddress] = rom[i];
        }
    }

    public byte GetByteAtAddress(int address)
    {
        return Memory[address];
    }

    public void SetByteAtAddress(int address, byte value)
    {
        Memory[address] = value;
    }
}
