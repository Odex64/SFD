using System;
using System.IO;
using System.Drawing;
class Program
{
    public static string data;

    [STAThread]
    private static void Main(string[] args)
    {
        string text;
        do
        {
            Console.Write("type image path: ");
            text = Console.ReadLine();
        }
        while (!CheckPath(text));
        Bitmap bitmap = new Bitmap(text);
        data = bitmap.Width + "_" + bitmap.Height + "|";
        for (int i = 0; i < bitmap.Width; i++)
        {
            for (int j = 0; j < bitmap.Height; j++)
            {
                SetData(bitmap.GetPixel(i, j));
                if (i != bitmap.Width - 1)
                {
                    data += "/";
                }
                else if (j != bitmap.Height - 1)
                {
                    data += "/";
                }
            }
        }
        System.Windows.Forms.Clipboard.SetText(data);
        Console.WriteLine("copied data");
        Console.ReadKey(intercept: true);
    }

    public static void SetData(Color color)
    {
        if (!AlphaCheck(color))
        {
            data = data + color.R + "," + color.G + "," + color.B;
        }
    }

    public static bool AlphaCheck(Color color)
    {
        if ((double)(int)color.A > 0.8)
        {
            return false;
        }
        return true;
    }

    public static bool CheckPath(string path)
    {
        if (File.Exists(path) && (path.EndsWith(".jpg") || path.EndsWith(".png") || path.EndsWith(".jpeg")))
        {
            return true;
        }
        return false;
    }
}
