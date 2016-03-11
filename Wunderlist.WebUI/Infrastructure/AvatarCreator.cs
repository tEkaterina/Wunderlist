using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace Wunderlist.WebUI.Infrastructure
{
    public static class AvatarCreator
    {
        private static readonly int width = 128;
        private static readonly int height = 128;

        public static byte[] Get(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (width <= 0)
                throw new ArgumentException("Avatar width must be greater than 0.", nameof(width));
            if (height <= 0)
                throw new ArgumentException("Avatar height must be greater than 0.", nameof(height));

            return CreateAvatarBitmap(name)
                .ToByteArray(ImageFormat.Bmp);
        }

        private static Bitmap CreateAvatarBitmap(string name)
        {
            var avatar = new Bitmap(width, height);
            var graphics = Graphics.FromImage(avatar);

            string firstLetter = name[0].ToString();

            var fontSize = 50;
            var drawFont = new Font("Arial", fontSize, FontStyle.Bold);

            float fontWidth = (fontSize * graphics.DpiX / 72);

            float letterX = (float)((width - fontWidth) / 2);
            float letterY = (float)(height - drawFont.Height) / 2;

            graphics.FillRectangle(new SolidBrush(Color.FromArgb(165, 148, 237)), 0, 0, width, height);
            graphics.DrawString(firstLetter, drawFont, Brushes.White, letterX, letterY);

            return avatar;
        }
    }
}