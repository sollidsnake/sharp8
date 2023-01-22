namespace Sharp8Core;

public class Chip8Memory : IChip8Memory
{
    private const int RomStartingAddress = 0x200;
    private const uint MemorySize = 4096;
    public byte[] Memory { get; } = new byte[MemorySize];
    private int _iRegisterAddress = 0;
    public byte[] RomBytes { get; private set; } = default!;

    // TODO: move programcounter from chip8memory to chip8
    public int ProgramCounter { get; set; } = RomStartingAddress;

    public Chip8Registers Registers { get; set; }
    public int IRegisterAddress
    {
        get { return _iRegisterAddress; }
        set { _iRegisterAddress = value; }
    }
    public int IRegisterValue
    {
        get { return Memory[_iRegisterAddress]; }
    }

    public Chip8Memory(Chip8Registers registers)
    {
        Memory = new byte[MemorySize];
        Registers = registers;
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

    public int CurrentInstruction()
    {
        return (Memory[ProgramCounter] << 8) | Memory[ProgramCounter + 1];
    }

    public void GoToAddress(int address)
    {
        ProgramCounter = address;
    }

    public void NextInstruction()
    {
        ProgramCounter += 2;
        CurrentInstruction();
    }
}
