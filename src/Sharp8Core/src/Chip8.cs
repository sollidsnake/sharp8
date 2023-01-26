using Sharp8Core.Instructions;

namespace Sharp8Core;

public class Chip8 : IChip8
{
    public IScreen Screen { get; }
    public IChip8Memory Memory { get; }
    public IChip8Stack Stack { get; }
    public int ProgramCounter { get; set; }
    private int _iRegisterAddress = 0;
    public Chip8Registers Registers { get; set; }
    public byte DelayTimer { get; set; }

    private const int CLOCK_SPEED_HZ = 500;

    public Chip8(IScreen screen, IChip8Memory memory, IChip8Stack stack)
    {
        Screen = screen;
        Memory = memory;
        Stack = stack;
        ProgramCounter = Memory.RomStartingAddress;
        Registers = new Chip8Registers();
    }

    public int IRegister
    {
        get => Registers.IRegister;
        set { Registers.IRegister = value; }
    }

    public int IRegisterValue
    {
        get { return Memory[Registers.IRegister]; }
        set => Memory.SetByteAtAddress(IRegister, (byte)value);
    }

    public void LoadRom(byte[] rom)
    {
        Memory.LoadRom(rom);
    }

    public void TickTimers()
    {
        if (DelayTimer > 0)
        {
            DelayTimer--;
        }
    }

    public InstructionManager ExecuteNextInstruction()
    {
        var instruction = CurrentInstruction();

        if (instruction.Action.Execute(this, instruction.Code))
        {
            NextInstruction();
        }

        return instruction;
    }

    private void NextInstruction()
    {
        ProgramCounter += 2;
    }

    public void GoToAddress(int address)
    {
        ProgramCounter = address;
    }

    public InstructionManager CurrentInstruction()
    {
        return InstructionManager.FromCode(
            (Memory[ProgramCounter] << 8) | Memory[ProgramCounter + 1]
        );
    }

    public void WaitClock()
    {
        Thread.Sleep((int)(1000f / CLOCK_SPEED_HZ));
    }

    public void PrintDebug(InstructionManager instruction)
    {
        Console.WriteLine(
            $"PC: {ProgramCounter:X4} - Instruction: {instruction.Code:X4} {instruction.Action.GetType().Name}"
        );
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"v{i}:{Registers.GetValue(i):X2} ");
        }
        Console.WriteLine(
            $"Instruction: {instruction.Code:X4} - {instruction.Action.GetType().Name}"
        );
    }

    public void PushToStack(int address)
    {
        Stack.Push(ProgramCounter + 2);
        ProgramCounter = address;
    }

    public void PopFromStack()
    {
        ProgramCounter = Stack.Pop();
    }
}
