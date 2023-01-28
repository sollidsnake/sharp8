namespace Sharp8Core;

public class Chip8Input
{
    private bool[] _keys = new bool[16];

    public bool this[int index]
    {
        get { return _keys[index]; }
        set { _keys[index] = value; }
    }
}
