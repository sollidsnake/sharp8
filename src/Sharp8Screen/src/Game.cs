using Raylib_cs;
using Sharp8Core;
using Sharp8Core.RomReader;
using System.IO.Abstractions;
using System.Numerics;

namespace Sharp8Screen;

public class Game
{
    public const int FPS = 240;
    private readonly int _scale = 16;
    private readonly int _scaleY = 16;
    private Chip8 _chip8;
    private Chip8Screen _screen = new Chip8Screen();

    public Game()
    {

        var memory = new Chip8Memory(new Chip8Registers());
        var romReader = new Chip8RomReader(new FileSystem());
        _chip8 = new Chip8(_screen, memory, romReader);
    }

    public void Run(string filename)
    {
        Raylib.InitWindow(64 * _scale, 32 * _scale, "Sharp8");
        Raylib.SetTargetFPS(FPS);
        _chip8.LoadRom(filename);
        var rayLibScreen = new RaylibScreen(_screen);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);

            rayLibScreen.Draw();

            _chip8.ExecuteUntilNextDraw();

            Raylib.EndDrawing();
        }

    }
}
