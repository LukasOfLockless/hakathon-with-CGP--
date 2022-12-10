using System;
using System.Drawing;

namespace CamBiometrics
{

  public class testdraw1
  {

    public static void Draw()
    {
/*string text = String.Format("Slate Blue has these ARGB values: Alpha:{0}, " +
        "red:{1}, green: {2}, blue {3}", new object[]{a, r, g, b});
    e.Graphics.DrawString(text,
        new Font(this.Font, FontStyle.Italic),
        new SolidBrush(slateBlue),
        new RectangleF(new PointF(0.0F, 0.0F), this.Size));*/
        Color ccc = Color.FromName("SlateBlue");


        var bitmap = new Bitmap(640, 480);

        {
            for (var y = 0; y < bitmap.Height; y++)
            for (var x = 0; x < bitmap.Width; x++)
            {
                bitmap.SetPixel(x, y,ccc );
            }
       }

       bitmap.Save("m.bmp");
    }

    

  }

}
