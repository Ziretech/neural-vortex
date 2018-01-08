using Adapter.OpenTK;
using Adapter.OpenTK.Grafik;
using Adapter.OpenTK.Kontroll;
using Adapter.Spelvärld;
using OpenTK.Input;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex;
using UseCase.NeuralVortex.Kontroll;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var tileset = new BildWrapper("Images/tiles.png");

            var inställningar = new SpelfönsterInställningar { Fullskärm = false, DoldaKanter = true, VSync = true, Bredd = 16 * 32, Höjd = 16 * 32 };
            var tangentmappning = new Dictionary<Key, Tangent> { { Key.Right, Tangent.Höger }, { Key.Left, Tangent.Vänster }, { Key.Up, Tangent.Upp }, { Key.Down, Tangent.Ner }, { Key.Escape, Tangent.Escape } };
            var fönster = new Spelfönster(tangentmappning, inställningar);
            var spelvärld = new Spelvärld();
            var glWrapper = new GLWrapper();
            var brickstorlek = new Rektangel(16, 16);
            var kamera = new Kamera(new Skärmyta(100, 100));
            var positionskonverterare = new Positionskonverterare(new Skärmyta(16, 16));

            var ucVisaSpelvärld = new VisaSpelvärld(spelvärld, kamera, positionskonverterare);
            var ucUppdateraSpelvärld = new UppdateraSpelvärld(spelvärld, kamera);
            var openTKHanterare = new GrafikHändelser(glWrapper, tileset, fönster, ucVisaSpelvärld, kamera);
            var kontrollhändelser = new KontrollHändelser(ucUppdateraSpelvärld, fönster);

            fönster.Laddare(openTKHanterare);
            fönster.StorleksÄndrare(openTKHanterare);
            fönster.Uppdaterare(openTKHanterare);
            fönster.Visare(openTKHanterare);
            fönster.Tangentbordsmottagare(kontrollhändelser);

            spelvärld.Huvudkaraktär = new Huvudkaraktär
            {
                Position = new Spelvärldsposition(0, 0),
                Grafik = new Bricka(glWrapper, kamera, new Skärmposition(0*16, 0*16), new Skärmyta(16, 16))
            };

            var definitioner = new Bricka[] {
                new Bricka(glWrapper, kamera, new Skärmposition(1 * 16, 0), new Skärmyta(16, 16)),
                new Bricka(glWrapper, kamera, new Skärmposition(2 * 16, 0), new Skärmyta(16, 16))
            };
            var karta = new int[] { 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0 };
            spelvärld.MiljöGrafik = new Brickfält(glWrapper, kamera, positionskonverterare, definitioner, 4, karta);
            

            fönster.Kör(60.0, 60.0);
        }
    }
}
