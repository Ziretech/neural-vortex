using Adapter.OpenTK;
using OpenTK;
using System;

namespace ConsoleApp
{
    class Spelfönster : IAvslutare, IBuffertväxlare
    {
        private GameWindow _openTKWindow;
        private IStorleksÄndrare _storleksÄndrare;

        public Spelfönster()
        {
            _openTKWindow = new GameWindow();
        }

        public Spelfönster(SpelfönsterInställningar inställningar)
        {
            _openTKWindow = new GameWindow();

            if (inställningar.Bredd > 0)
            {
                _openTKWindow.Width = inställningar.Bredd;
            }
            if(inställningar.Höjd > 0)
            {
                _openTKWindow.Height = inställningar.Höjd;
            }
            if(inställningar.VSync)
            {
                _openTKWindow.VSync = VSyncMode.On;
            }
            if(inställningar.DoldaKanter)
            {
                _openTKWindow.WindowBorder = WindowBorder.Hidden;
            }
            if(inställningar.Fullskärm)
            {
                _openTKWindow.WindowState = WindowState.Fullscreen;
            }
        }

        public void Laddare(ILaddare laddare)
        {
            _openTKWindow.Load += laddare.Ladda;
        }

        public void StorleksÄndrare(IStorleksÄndrare storleksÄndrare)
        {
            _storleksÄndrare = storleksÄndrare;
            _openTKWindow.Resize += ÄndraStorlek;
        }

        public void Uppdaterare(IUppdaterare uppdaterare)
        {
            _openTKWindow.UpdateFrame += uppdaterare.Uppdatera;
        }

        public void Visare(IVisare visare)
        {
            _openTKWindow.RenderFrame += visare.Visa;
        }

        public void ÄndraStorlek(object avsändare, EventArgs händelse)
        {
            if(_storleksÄndrare != null)
            {
                _storleksÄndrare.ÄndraStorlek(_openTKWindow.Width, _openTKWindow.Height);
            }            
        }

        public void Avsluta()
        {
            _openTKWindow.Exit();
        }

        public void Kör(double uppdateringarISekunden, double visningarISekunden)
        {
            _openTKWindow.Run(uppdateringarISekunden, visningarISekunden);
        }

        public void VäxlaBuffert()
        {
            _openTKWindow.SwapBuffers();
        }
    }
}
