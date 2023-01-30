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
        var spriteAddress = chip8.Registers.I;

        var x = chip8.Registers.GetValue(vx);
        var y = chip8.Registers.GetValue(vy);

        var collision = false;
        for (int line = 0; line < height; line++)
        {
            var bytesToDraw = chip8.Memory.Memory[spriteAddress];

            var _collision = chip8.Screen.DrawSpriteLine(
                x,
                line + y,
                bytesToDraw
            );
            if (!collision)
            {
                collision = _collision;
            }
            spriteAddress += 1;
        }

        chip8.Registers.SetVIndex(0xf, collision);
        chip8.Screen.ScreenUpdated(x, y, height);

        return true;
    }
}
