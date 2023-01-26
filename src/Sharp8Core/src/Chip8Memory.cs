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

        SetupFonts();
    }

    public void SetupFonts()
    {
        var fontSet = new byte[]
        {
            0xF0, 0x90, 0x90, 0x90, 0xF0, // 0
            0x20, 0x60, 0x20, 0x20, 0x70, // 1
            0xF0, 0x10, 0xF0, 0x80, 0xF0, // 2
            0xF0, 0x10, 0xF0, 0x10, 0xF0, // 3
            0x90, 0x90, 0xF0, 0x10, 0x10, // 4
            0xF0, 0x80, 0xF0, 0x10, 0xF0, // 5
            0xF0, 0x80, 0xF0, 0x90, 0xF0, // 6
            0xF0, 0x10, 0x20, 0x40, 0x40, // 7
            0xF0, 0x90, 0xF0, 0x90, 0xF0, // 8
            0xF0, 0x90, 0xF0, 0x10, 0xF0, // 9
            0xF0, 0x90, 0xF0, 0x90, 0x90, // A
            0xE0, 0x90, 0xE0, 0x90, 0xE0, // B
            0xF0, 0x80, 0x80, 0x80, 0xF0, // C
            0xE0, 0x90, 0x90, 0x90, 0xE0, // D
            0xF0, 0x80, 0xF0, 0x80, 0xF0, // E
            0xF0, 0x80, 0xF0, 0x80, 0x80  // F
        };

        Array.Copy(fontSet, Memory, fontSet.Length);
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
