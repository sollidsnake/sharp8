namespace Sharp8Core.Instructions;

public static class InstructionDictionary
{
    private static Dictionary<
        string,
        InstructionTable
    > _instructionsDictionary = new Dictionary<string, InstructionTable >()
    {
        {  "00E0", InstructionTable.ClearScreen },
        {  "1NNN", InstructionTable.Jump },
        {  "6XNN", InstructionTable.SetRegister },
        {  "7XNN", InstructionTable.AddValueToRegister },
        {  "ANNN", InstructionTable.SetIndexRegister },
        {  "DXYN", InstructionTable.Draw },
    };

    public static InstructionTable GetInstruction(string instruction)
    {
        return _instructionsDictionary[instruction];
    }
}
