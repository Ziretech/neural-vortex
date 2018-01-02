using Adapter.OpenTK;
using System;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;

namespace ConsoleApp
{
    class BildDataWrapper : IBildData
    {
        private BitmapData _data;

        public BildDataWrapper(BitmapData data)
        {
            _data = data;
        }

        public void DefinieraTexturbild()
        {
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, _data.Width, _data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, _data.Scan0);
        }
    }
}
