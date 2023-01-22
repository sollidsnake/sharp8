using SFML.System;
using Sharp8Core;
using Raylib_cs;

namespace Sharp8Screen;

public class RaylibScreen : Chip8Screen
{
    private readonly Vector2i _scale = new Vector2i(16, 16);
    private IScreen _screen;

    public RaylibScreen(IScreen screen)
    {
        _screen = screen;
        // Raylib.SetTargetFPS(60);
    }

    public void DrawOpenSquare(int x, int y)
    {
        // draw 5 lines to maake a square

        Raylib.DrawLine(
            x * _scale.X,
            y * _scale.Y,
            (x + 1) * _scale.X,
            y * _scale.Y,
            Color.WHITE
        );
        Raylib.DrawLine(
            x * _scale.X,
            y * _scale.Y,
            x * _scale.X,
            (y + 1) * _scale.Y,
            Color.WHITE
        );
        Raylib.DrawLine(
            (x + 1) * _scale.X,
            y * _scale.Y,
            (x + 1) * _scale.X,
            (y + 1) * _scale.Y,
            Color.WHITE
        );
        Raylib.DrawLine(
            x * _scale.X,
            (y + 1) * _scale.Y,
            (x + 1) * _scale.X,
            (y + 1) * _scale.Y,
            Color.WHITE
        );
    }

    public void DrawGrid()
    {
        for (int x = 0; x < _screen.Width; x++)
        {
            for (int y = 0; y < _screen.Height; y++)
            {
                DrawOpenSquare(x, y);
            }
        }
    }

    public void Draw()
    {
        DrawGrid();
        DrawChip8();
    }

    public void DrawChip8()
    {
        for (int x = 0; x < _screen.Width; x++)
        {
            for (int y = 0; y < _screen.Height; y++)
            {
                if (_screen.Grid[x, y])
                {
                    Raylib.DrawRectangle(
                        x * _scale.X,
                        y * _scale.Y,
                        _scale.X,
                        _scale.Y,
                        Color.WHITE
                    );
                }
            }
        }
    }
}
