using Adapter.OpenTK;
using Adapter.OpenTK.Grafik;
using Adapter.Spelvärld;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var tileset = new BildWrapper("c:/temp/tiles.png");

            var inställningar = new SpelfönsterInställningar { Fullskärm = false, DoldaKanter = true, VSync = true, Bredd = 16 * 32, Höjd = 16 * 32 };
            var fönster = new Spelfönster(inställningar);
            var spelvärld = new Spelvärld();
            var glWrapper = new GLWrapper();

            var ucVisaSpelvärld = new VisaSpelvärld(spelvärld);
            var openTKHanterare = new GrafikHändelser(fönster, glWrapper, tileset, fönster, ucVisaSpelvärld);

            fönster.Laddare(openTKHanterare);
            fönster.StorleksÄndrare(openTKHanterare);
            fönster.Uppdaterare(openTKHanterare);
            fönster.Visare(openTKHanterare);

            spelvärld.Huvudkaraktär = new Huvudkaraktär
            {
                Position = new Spelvärldsposition(0, 0),
                Grafik = new Bricka(glWrapper, 0, 0, 16, 16)
            };

            fönster.Kör(60.0, 60.0);
        }
    }
}
