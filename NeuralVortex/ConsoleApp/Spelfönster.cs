using Adapter.OpenTK;
using Adapter.OpenTK.Grafik;
using Adapter.OpenTK.Kontroll;
using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using UseCase.NeuralVortex.Kontroll;

namespace ConsoleApp
{
    class Spelfönster : IAvslutare, IBuffertväxlare
    {
        private GameWindow _openTKWindow;
        private IStorleksÄndrare _storleksÄndrare;
        private ITangentmottagare _tangentmottagare;
        private Dictionary<Key, Tangent> _openTKTangentMappning;

        public Spelfönster(Dictionary<Key, Tangent> tangentmappning, SpelfönsterInställningar inställningar = null)
        {
            _openTKTangentMappning = tangentmappning;
            _openTKWindow = new GameWindow();            

            if(inställningar != null)
            {
                if (inställningar.Bredd > 0)
                {
                    _openTKWindow.Width = inställningar.Bredd;
                }
                if (inställningar.Höjd > 0)
                {
                    _openTKWindow.Height = inställningar.Höjd;
                }
                if (inställningar.VSync)
                {
                    _openTKWindow.VSync = VSyncMode.On;
                }
                if (inställningar.DoldaKanter)
                {
                    _openTKWindow.WindowBorder = WindowBorder.Hidden;
                }
                if (inställningar.Fullskärm)
                {
                    _openTKWindow.WindowState = WindowState.Fullscreen;
                }
            }            
        }

        public void Tangentbordsmottagare(ITangentmottagare tangentmottagare)
        {
            _tangentmottagare = tangentmottagare;
            _openTKWindow.KeyDown += TangentTrycksNed;
        }

        public void TangentTrycksNed(object avsändare, KeyboardKeyEventArgs händelse)
        {
            if(_openTKTangentMappning.ContainsKey(händelse.Key))
            {
                _tangentmottagare.TangentTrycksNed(_openTKTangentMappning[händelse.Key]);
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
