


using SkiaSharp;

using (FileStream src = File.OpenRead("C:\\Users\\joshu\\Desktop\\CodeBase\\Comp101-1-2411873\\Class Work\\Tinkering Graphics\\layers.png"))
{

    SKBitmap pixelData = SKBitmap.Decode(src);
    // TODO close the file stream here

    // get the colour at (0,0) and output it's values to the screen

    for (int x = 0; x < pixelData.Width; x++)
    {
        for (int y = 0; y < pixelData.Height; y++)
        {
            SkiaSharp.SKColor colour = pixelData.GetPixel(x, y);
            Console.WriteLine("Red: {0}, Green: {1}, Blue: {2}, #{0:x}{1:x}{2:x}", colour.Red, colour.Green, colour.Blue);

        }    }

}


