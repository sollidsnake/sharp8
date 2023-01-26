using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Sharp8Core;
using Sharp8Core.RomReader;
using System.IO.Abstractions;

namespace Sharp8Screen;

public class Game
{
    public const int FPS = 60;
    private readonly Vector2i _scale = new Vector2i(16, 16);
    private IChip8 _chip8;
    private Screen _screen;
    private const int INSTRUCTIONS_PER_FRAME = 10;
    public bool Debug = true;
    private bool _waitingForDebugKey = false;

    public Game()
    {
        _screen = new Screen();
        var memory = new Chip8Memory();
        var romReader = new Chip8RomReader(new FileSystem());
        _chip8 = new Chip8(_screen, memory, new Chip8Stack());
    }

    public void DebugWaitKeyPress()
    {
        _waitingForDebugKey = true;
        _screen.Window.KeyReleased += new EventHandler<KeyEventArgs>((sender, e) =>
        {
            if (e.Code == Keyboard.Key.F10)
            {
                _waitingForDebugKey = false;
            }
        });

        _screen.Window.WaitAndDispatchEvents();
    }

    public void Run(string filename)
    {
        _chip8.LoadRom(File.ReadAllBytes(filename));
        _screen.Window.SetFramerateLimit(FPS);

        var clock = new Clock();

        while (_screen.Window.IsOpen)
        {
            var elapsed = clock.ElapsedTime;

            _screen.Window.DispatchEvents();

            for (int i = 0; i < INSTRUCTIONS_PER_FRAME; i++)
            {
                if (Debug)
                {
                    DebugWaitKeyPress();
                }
                _chip8.ExecuteNextInstruction();
            }

            _screen.Draw();
            _chip8.TickTimers();

            var time = clock.ElapsedTime;
            Console.WriteLine($"FPS: {1f / time.AsSeconds()}");
            _chip8.PrintDebug();
            clock.Restart();
        }
    }

    private static void OnClose(object sender, EventArgs e)
    {
        ((RenderWindow)sender).Close();
    }
}
