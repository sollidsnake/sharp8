namespace Sharp8Core;

public class Chip8Screen : IScreen
{
    public int Width => 64;
    public int Height => 32;
    public bool[,] Grid { get; } = new bool[64, 32];

    public void Clear() { }

    public virtual bool DrawSpriteLine(int startingX, int y, int bytes)
    {
        bool collision = false;
        for (int i = 0; i < 8; i++)
        {
            int x = (startingX + i);
            if (x >= Width)
            {
                x = 0;
            }
            if (y >= Height)
            {
                y = 0;
            }

            var pixel = (((bytes << i) & 128) >> 7) != 0;
            if (Grid[x, y] && pixel)
            {
                collision = true;
            }
            Grid[x, y] ^= pixel;
        }

        return collision;
    }

    public bool GetPixel(int x, int y)
    {
        return Grid[x, y];
    }

    public bool IsPixelSet(byte x, byte y)
    {
        throw new NotImplementedException();
    }

    public virtual void ScreenUpdated(int x, int y, int height) { }

    public void SetPixel(byte x, byte y)
    {
        throw new NotImplementedException();
    }

    public void UnsetPixel(byte x, byte y)
    {
        throw new NotImplementedException();
    }
}
