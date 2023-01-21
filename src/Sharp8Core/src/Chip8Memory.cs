namespace Sharp8Core;

public class Chip8Memory
{
    private const int RomStartingAddress = 0x200;
    private const uint MemorySize = 4096;
    public byte[] Memory { get; } = new byte[MemorySize];
    private int _iRegisterAddress = 0;
    public byte[] RomBytes { get; private set; } = default!;
    public int PC { get; private set; } = RomStartingAddress;
    public Chip8Registers Registers;
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
        return (Memory[PC] << 8) | Memory[PC + 1];
    }

    public void NextInstruction()
    {
        PC += 2;
        CurrentInstruction();
    }
}
