namespace Sharp8Core;

public interface IChip8Memory
{
    byte[] Memory { get; }
    byte[] RomBytes { get; }
    int ProgramCounter { get; set; }
    Chip8Registers Registers { get; set; }
    int IRegisterAddress { get; set; }
    int IRegisterValue { get; }

    int CurrentInstruction();
    byte GetByteAtAddress(int address);
    void GoToAddress(int address);
    void LoadRom(byte[] rom);
    void NextInstruction();
}
