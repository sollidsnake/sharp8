namespace Sharp8Core;

public interface IChip8Stack
{
    int Pop();
    void Push(int value);
}

public class Chip8Stack : IChip8Stack
{
    private readonly int[] _stack;
    private int _stackPointer;

    public Chip8Stack()
    {
        _stack = new int[16];
        _stackPointer = 0;
    }

    public void Push(int value)
    {
        _stack[_stackPointer] = value;
        _stackPointer++;
    }

    public int Pop()
    {
        _stackPointer--;
        return _stack[_stackPointer];
    }
}
