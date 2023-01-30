using System.Collections.ObjectModel;

namespace Sharp8.Core;

public class HexInstructions
{
    public const int InstructionSize = 2;
    public const char InstructionSeparator = '-';
    public Collection<string>? Instructions { get; private set; }

    public HexInstructions LoadInstructions(string instructions)
    {
        int count = 1;
        string currentInstruction = "";
        Collection<string> formattedInstructions = new();
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
