namespace Sharp8Core.Instructions;

/**
 *
 * instruction 0xDXYZ
 * draws on coordinates XY a sprite of height Z
 */

public class InstructionDrawSprite : IInstruction
{
    public bool Execute(IChip8 chip8, int instructionCode)
    {
        var vx = (instructionCode >> 8) & 0xf;
        var vy = (instructionCode >> 4) & 0xf;
        var height = instructionCode & 0x000f;
        var spriteAddress = chip8.IRegister;

        var x = chip8.Registers.GetValue(vx);
        var y = chip8.Registers.GetValue(vy);

        for (int line = 0; line < height; line++)
        {
            var bytesToDraw = chip8.Memory.Memory[spriteAddress];

            chip8.Screen.DrawSpriteLine(x, line + y, bytesToDraw);
            spriteAddress += 1;
        }

        chip8.Screen.ScreenUpdated(x, y, height);

        return true;
    }
}
