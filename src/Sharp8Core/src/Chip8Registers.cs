namespace Sharp8Core;

public class Chip8Registers
{
    // vx
    private int[] _register = new int[16];

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

    public Chip8Registers setVIndex(int index, int value)
    {
        _register[index] = value;
        return this;
    }

    public int GetRegisterValue(int index)
    {
        return _register[index];
    }
}
