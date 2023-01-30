namespace Sharp8Core.Instructions;

/// <summary>
/// BNNN
///
/// Jump to address NNN + V0
/// </summary>
public class InstructionJumpToAddressNNNPlusV0 : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var address = instructionCode & 0x0FFF;

        chip8.ProgramCounter = address + chip8.Registers[0];

        return true;
    }
}
