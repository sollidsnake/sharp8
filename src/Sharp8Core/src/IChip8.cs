using Sharp8Core.Instructions;

namespace Sharp8Core;

public interface IChip8
{
    public IScreen Screen { get; }
    public IChip8Memory Memory { get; }
    private const int CLOCK_SPEED = 500; // Hz

    public void LoadRom(byte[] rom)
    {
        Memory.LoadRom(rom);
    }

    public InstructionManager ExecuteNextInstruction();

    public void WaitClock();

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
