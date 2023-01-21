using System.Text;

namespace Sharp8Core;

public interface IScreen
{
    public int Width { get; }
    public int Height { get; }
    public bool[,] Grid { get; }

    public int ScreenSize
    {
        get { return Width * Height; }
    }

    void Clear();
    void DrawSpriteLine(int x, int y, int bytes);
    bool GetPixel(int x, int y);

    public string GenGridTableWithBorders()
    {
        var sb = new StringBuilder();
        for (int y = 0; y < Height; y++)
        {
            sb.Append("|");
            for (int x = 0; x < Width; x++)
            {
                sb.Append(Grid[x, y] ? "X" : " ");
            }
            sb.AppendLine("|");
        }

        return sb.ToString();
    }
}
