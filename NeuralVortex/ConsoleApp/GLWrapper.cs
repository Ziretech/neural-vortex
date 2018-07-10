using Adapter.OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using Adapter.OpenTK.Grafik;

namespace ConsoleApp
{
    class GLWrapper : IGrafikkommandon
    {
        public void Aktivera2DTexturering()
        {
            GL.Enable(EnableCap.Texture2D);
        }

        public void AktiveraBlandning()
        {
            GL.Enable(EnableCap.Blend);
        }

        public void AvslutaDefinitioner()
        {
            GL.End();
        }

        public void DefinieraFyrkanter()
        {
            GL.Begin(PrimitiveType.Quads);
        }

        public int GenereraTextur()
        {
            return GL.GenTexture();
        }

        public void Hörnkoordinat(int x, int y)
        {
            GL.Vertex2(x, y);
        }

        public void NollställMatris()
        {
            GL.LoadIdentity();
        }

        public void OrtogonalProjektion(double vänster, double höger, double nere, double uppe, double nära, double borta)
        {
            GL.Ortho(vänster, höger, nere, uppe, nära, borta);
        }

        public void Skalningsmatris(double breddfaktor, double höjdfaktor)
        {
            GL.Scale(breddfaktor, höjdfaktor, 1.0);
        }

        public void Texturkoordinat(int x, int y)
        {
            GL.TexCoord2(x, y);
        }

        public void TömRityta()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public void Visningsområde(int x, int y, int bredd, int höjd)
        {
            GL.Viewport(x, y, bredd, höjd);
        }

        public void VäljAktivTextur(int texturId)
        {
            GL.BindTexture(TextureTarget.Texture2D, texturId);
        }

        public void VäljAlphakanalBlandning()
        {
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        }

        public void VäljModellmatris()
        {
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void VäljNärmasteFärgVidTexturförminskning()
        {
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
        }

        public void VäljNärmasteFärgVidTexturförstoring()
        {
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
        }

        public void VäljProjektionmatris()
        {
            GL.MatrixMode(MatrixMode.Projection);
        }

        public void VäljTexturmatris()
        {
            GL.MatrixMode(MatrixMode.Texture);
        }
    }
}
