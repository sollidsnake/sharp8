using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Sharp8Core;

namespace Sharp8Screen;

public class Screen : Chip8Screen
{
    public RenderWindow Window { get; }
    private readonly string _title = "Sharp8";
    private readonly Vector2u _scale = new(18, 18);
    private readonly VertexArray[,] _visualGrid;
    private Color _colorBG = Color.Black;
    private Color _colorFG = Color.Green;
    private readonly RectangleShape[,] _pixels = new RectangleShape[64, 32];

    public Screen()
    {
        Window = new RenderWindow(
            new VideoMode((uint)Width * _scale.X, (uint)Height * _scale.Y),
            _title
        );

        _visualGrid = CreateGrid();

        Window.Closed += (sender, args) => Window.Close();
        CreatePixels();
    }

    private void CreatePixels()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                var pixel = CreatePixel(x, y, _colorBG);
                _pixels[x, y] = pixel;
            }
        }
    }

    public override void ScreenUpdated(int x, int y, int height)
    {
        var maxX = x + 8;
        if (maxX > Width)
        {
            maxX = Width;
        }

        for (int i = x; i < maxX; i++)
        {
            var maxY = y + height;
            if (maxY > Height)
            {
                maxY = Height;
            }
            for (int j = y; j < maxY; j++)
            {
                DrawPixel(i, j);
            }
        }
    }

    public void Draw()
    {
        DrawPixels();
        // DrawGrid();
        Window.Display();
    }

    public void DrawPixels()
    {
        for (var x = 0; x < Width; x++)
        {
            for (var y = 0; y < Height; y++)
            {
                DrawPixel(x, y);
            }
        }
    }

    private void DrawPixel(int x, int y)
    {
        _pixels[x, y].FillColor = Grid[x, y] ? _colorFG : _colorBG;
        Window.Draw(_pixels[x, y]);
    }

    public void DrawGrid()
    {
        for (var x = 0; x < Width; x++)
        {
            for (var y = 0; y < Height; y++)
            {
                Window.Draw(_visualGrid[x, y]);
            }
        }
    }

    public RectangleShape CreatePixel(int x, int y, Color color)
    {
        return new RectangleShape(new Vector2f(_scale.X, _scale.Y))
        {
            FillColor = color,
            Position = new Vector2f(x * _scale.X, y * _scale.Y)
        };
    }

    private VertexArray CreateSquareVertex(int unscaledX, int unscaledY)
    {
        var x = unscaledX * _scale.X;
        var y = unscaledY * _scale.Y;

        var vertex = new VertexArray(PrimitiveType.LineStrip, 5);
        vertex[0] = new Vertex(new Vector2f(x, y));
        vertex[1] = new Vertex(new Vector2f(x + _scale.X, y));
        vertex[2] = new Vertex(new Vector2f(x + _scale.X, y + _scale.Y));
        vertex[3] = new Vertex(new Vector2f(x, y + _scale.Y));
        vertex[4] = new Vertex(new Vector2f(x, y));

        return vertex;
    }

    private VertexArray[,] CreateGrid()
    {
        var vertexes = new VertexArray[Width, Height];

        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                vertexes[i, j] = CreateSquareVertex(i, j);
            }
        }

        return vertexes;
    }
}
