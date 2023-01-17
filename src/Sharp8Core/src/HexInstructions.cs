namespace Sharp8Core;

public class HexInstructions
{
    public const int InstructionSize = 2;
    public const char InstructionSeparator = '-';
    public List<string>? Instructions { get; private set; }

    public HexInstructions LoadInstructions(string instructions)
    {
        int count = 1;
        string currentInstruction = "";
        List<string> formattedInstructions = new List<string>();
        foreach (var hex in instructions.Split(InstructionSeparator))
        {
            currentInstruction += hex;

            if (count == InstructionSize)
            {
                formattedInstructions.Add(currentInstruction);
                currentInstruction = "";
                count = 1;
                continue;
            }
            count++;
        }

        Instructions = formattedInstructions;

        return this;
    }

}
