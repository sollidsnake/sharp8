namespace Sharp8Core.Instructions;

public static class InstructionDictionary
{
    private static Dictionary<
        string,
        Instruction
    > _instructionsDictionary = new Dictionary<string, Instruction >()
    {
        {  "00E0", Instruction.ClearScreen },
        {  "1NNN", Instruction.Jump },
        {  "6XNN", Instruction.SetRegister },
        {  "7XNN", Instruction.AddValueToRegister },
        {  "ANNN", Instruction.SetIndexRegister },
        {  "DXYN", Instruction.Draw },
    };

    public static Instruction GetInstruction(string instruction)
    {
        return _instructionsDictionary[instruction];
    }
}
