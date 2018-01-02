using Adapter.OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class BildWrapper : IBild
    {
        private Bitmap _bitmap;
        private BitmapData _data;

        public BildWrapper(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }

        public BildWrapper(string filnamn)
        {
            try
            {
                _bitmap = new Bitmap(filnamn);
            }
            catch(ArgumentException e)
            {
                throw new ArgumentException($"Kunde inte hitta bildfilen med namn {filnamn}.", e);
            }
        }

        public int Bredd => _bitmap.Width;

        public int Höjd => _bitmap.Height;

        public void FrigörBilddata()
        {
            if(_data == null)
            {
                throw new InvalidOperationException("Går ej att frigöra bilddata som inte låsts.");
            }
            _bitmap.UnlockBits(_data);
            _data = null;
        }

        public IBildData LåsBilddata32ARGB()
        {
            if(_data != null)
            {
                throw new InvalidOperationException("Går ej att låsa bilddata innan tidigare låst data frigjorts.");
            }
            var yta = new Rectangle(0, 0, _bitmap.Width, _bitmap.Height);
            _data = _bitmap.LockBits(yta, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            return new BildDataWrapper(_data);
        }
    }
}
