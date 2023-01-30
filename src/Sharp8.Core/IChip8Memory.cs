namespace Sharp8.Core;

public interface IChip8Memory
{
    int this[int address] => Memory[address];
    int RomStartingAddress { get; }

#pragma warning disable CA1819
    byte[] Memory { get; }
    byte[] RomBytes { get; }
    byte GetByteAtAddress(int address);
    void SetByteAtAddress(int address, byte value);
    void LoadRom(byte[] rom);
}
