namespace Sharp8Core;

public interface IChip8Memory
{
    int this[int address] => Memory[address];
    int RomStartingAddress { get; }
    byte[] Memory { get; }
    byte[] RomBytes { get; }
    byte GetByteAtAddress(int address);
    void SetByteAtAddress(int address, byte value);
    void LoadRom(byte[] rom);
}
