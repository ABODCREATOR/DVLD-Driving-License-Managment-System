using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;
namespace Driving_License_Management_System
{
    public static class clsUtil
    {
        public static Image SetImageOpacity(Image img , int opacity)
        {
            opacity = Math.Max(0, Math.Min(100, opacity));
            float alpha = opacity / 100f;

            Bitmap bmp = new Bitmap(img.Width, img.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = alpha;

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(
                    matrix,
                    ColorMatrixFlag.Default,
                    ColorAdjustType.Bitmap);

                g.DrawImage(
                    img,
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    0,
                    0,
                    img.Width,
                    img.Height,
                    GraphicsUnit.Pixel,
                    attributes);
            }

            return bmp;
        }

        public static Color SetColorOpacity(Color color, int opacity)
        {
            opacity = Math.Max(0, Math.Min(100, opacity));

            int alpha = (int)(255 * (opacity / 100.0));

            return Color.FromArgb(
                alpha,
                color.R,
                color.G,
                color.B);
        }

        public static string DateToShort(DateTime dt1)
        {
            return dt1.ToString("dd/MMM/yyyy");
        }
    }
}
