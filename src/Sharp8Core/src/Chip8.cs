using Sharp8Core.Instructions;

namespace Sharp8Core;

public class Chip8: IChip8
{
    public IScreen Screen { get; }
    public IChip8Memory Memory { get; }
    private const int CLOCK_SPEED = 500; // Hz

    public Chip8(IScreen screen, IChip8Memory memory)
    {
        Screen = screen;
        Memory = memory;
    }

    public void LoadRom(byte[] rom)
    {
        Memory.LoadRom(rom);
    }

    public InstructionManager ExecuteNextInstruction()
    {
        var currentInstruction = Memory.CurrentInstruction();
        var instruction = InstructionManager.FromCode(currentInstruction);

        if (instruction.Action.Execute(this, instruction.Code))
        {
            Memory.NextInstruction();
        }

        return instruction;
    }

    public void WaitClock()
    {
        Thread.Sleep((int)(1000f / CLOCK_SPEED));
    }

    public void PrintDebug(InstructionManager instruction)
    {
        Console.WriteLine(
            $"PC: {Memory.ProgramCounter:X4} - Instruction: {instruction.Code:X4} {instruction.Action.GetType().Name}"
        );
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"v{i}:{Memory.Registers.GetValue(i):X2} ");
        }
        Console.WriteLine(
            $"Instruction: {instruction.Code:X4} - {instruction.Action.GetType().Name}"
        );
    }
}
