namespace Sharp8.Core;

public interface IChip8StackList
{
    int Pop();
    void Push(int value);
    public uint StackPointer { get; }
}

public class Chip8StackList : IChip8StackList
{
    private readonly int[] _stack;
    public uint StackPointer { get; private set; }

    public Chip8StackList()
    {
        _stack = new int[16];
        StackPointer = 0;
    }

    public void Push(int value)
    {
        _stack[StackPointer] = value;
        StackPointer++;
    }

    public int Pop()
    {
        StackPointer--;
        return _stack[StackPointer];
    }
}
