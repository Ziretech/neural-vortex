using Adapter.OpenTK;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var tileset = new BildWrapper("c:/temp/tiles.png");

            var inställningar = new SpelfönsterInställningar { Fullskärm = false, DoldaKanter = true, VSync = true, Bredd = 16 * 32, Höjd = 16 * 32 };
            var fönster = new Spelfönster(inställningar);
            var openTKHanterare = new GrafikHändelser(fönster, new GLWrapper(), tileset, fönster);

            fönster.Laddare(openTKHanterare);
            fönster.StorleksÄndrare(openTKHanterare);
            fönster.Uppdaterare(openTKHanterare);
            fönster.Visare(openTKHanterare);
            fönster.Kör(60.0, 60.0);
        }
    }
}
