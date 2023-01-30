namespace Sharp8.Core;

public class Chip8Registers
{
    // vx
    private int[] _register = new int[16];
    public int I { get; set; }

    public int this[int index]
    {
        get => _register[index];
        set => _register[index] = value;
    }

    public Chip8Registers()
    {
        PopulateRegisters();
    }

    private void PopulateRegisters()
    {
        for (int i = 0; i < _register.Length; i++)
        {
            _register[i] = 0;
        }
    }

    public Chip8Registers SetVIndex(int index, int value)
    {
        _register[index] = value;
        return this;
    }

    public Chip8Registers SetVIndex(int index, bool value)
    {
        return SetVIndex(index, value ? 1 : 0);
    }

    public virtual int GetValue(int index)
    {
        return _register[index];
    }
}
