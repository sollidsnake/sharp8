namespace Sharp8.Core;

public interface IChip8
{
    public IScreen Screen { get; }
    public IChip8Memory Memory { get; }
    public int ProgramCounter { get; set; }
    public IChip8StackList Stack { get; }
    public Chip8Registers Registers { get; set; }
    public Chip8Input Input { get; set; }
    public byte DelayTimer { get; set; }
    public byte SoundTimer { get; set; }
    public int IRegisterValue { get; set; }
    public byte? WaitingForKeyPressOnRegister { get; set; }

    public void LoadRom(byte[] rom)
    {
        Memory.LoadRom(rom);
    }

    public InstructionManager ExecuteNextInstruction();
    public void WaitKeyPressed(byte key);

    public InstructionManager CurrentInstruction();
    public void GoToAddress(int address);
    public void WaitClock();
    public void PushToStack(int address);
    public void PopFromStack();
    public void TickTimers();

    public void PrintDebug()
    {
        Console.WriteLine(
            $"PC: {ProgramCounter:X4} I: {Registers.I:X4} SP: {Stack.StackPointer:X2} DT: {DelayTimer:X2}"
        );
        for (int i = 0; i < 16; i++)
        {
            Console.Write($"v{i:X}:{Registers[i]:X2}|");
        }
        Console.WriteLine();
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
}
