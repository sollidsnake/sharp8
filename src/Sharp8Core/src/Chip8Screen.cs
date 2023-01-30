namespace Sharp8Core;

public class Chip8Screen : IScreen
{
    public int Width => 64;
    public int Height => 32;
    public bool[,] Grid { get; } = new bool[64, 32];

    public void Clear()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Grid[x, y] = false;
            }
        }
    }

    public virtual bool DrawSpriteLine(int x, int y, int bytes)
    {
        bool collision = false;
        for (int i = 0; i < 8; i++)
        {
            int currentX = x + i;
            if (currentX >= Width)
            {
                currentX = 0;
            }
            if (y >= Height)
            {
                y = 0;
            }

            var pixel = (((bytes << i) & 128) >> 7) != 0;
            if (Grid[currentX, y] && pixel)
            {
                collision = true;
            }
            Grid[currentX, y] ^= pixel;
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
