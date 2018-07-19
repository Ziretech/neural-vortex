using Adapter.OpenTK;
using Adapter.OpenTK.Grafik;
using Adapter.OpenTK.Kontroll;
using Adapter.Spelvärld;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex;
using UseCase.NeuralVortex.AI;
using UseCase.NeuralVortex.Kontroll;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Initiera();
            program.Kör();
        }

        private Spelfönster _fönster;

        private void Initiera()
        {
            var tileset = new BildWrapper("Images/tiles.png");

            var inställningar = new SpelfönsterInställningar
            {
                Fullskärm = true,
                DoldaKanter = true,
                VSync = true,
                Bredd = 16 * 32,
                Höjd = 16 * 32
            };
            var tangentmappning = new Dictionary<Key, Tangent> {
                { Key.Right, Tangent.Höger },
                { Key.Left, Tangent.Vänster },
                { Key.Up, Tangent.Upp },
                { Key.Down, Tangent.Ner },
                { Key.Escape, Tangent.Escape }
            };
            _fönster = new Spelfönster(tangentmappning, inställningar);
            var spelvärld = new Spelvärld();
            var grafikkommandon = new GLWrapper();
            var brickstorlek = new Rektangel(16, 16);
            var kamera = new Kamera(new Skärmyta(100, 100));
            var positionskonverterare = new Positionskonverterare(new Skärmyta(16, 16));

            var ucVisaSpelvärld = new VisaSpelvärld(spelvärld, kamera, positionskonverterare);

            const int kartbredd = 16;
            var kartritare = new Kartritare(new Spelvärldsyta(kartbredd, 16));
            kartritare.SkapaRum(new Spelvärldsområde(1, 1, 8, 8));
            kartritare.SkapaDörr(new Spelvärldsposition(8, 4));
            kartritare.SkapaRum(new Spelvärldsområde(9, 2, 15, 10));
            var karta = kartritare.ByggKarta();
            var hinderlista = new[] { 0 };
            var hinderkarta = karta.SkapaHinderkarta(hinderlista);

            var ucUppdateraSpelvärld = new UppdateraSpelvärld(spelvärld, kamera, hinderkarta);
            var openTKHanterare = new GrafikHändelser(grafikkommandon, tileset, _fönster, ucVisaSpelvärld, kamera);
            var kontrollhändelser = new KontrollHändelser(ucUppdateraSpelvärld, _fönster);

            _fönster.Laddare(openTKHanterare);
            _fönster.StorleksÄndrare(openTKHanterare);
            _fönster.Uppdaterare(openTKHanterare);
            _fönster.Visare(openTKHanterare);
            _fönster.Tangentbordsmottagare(kontrollhändelser);

            spelvärld.Huvudkaraktär = new Huvudkaraktär
            {
                Position = new Spelvärldsposition(1, 1),
                Grafik = new Bricka(grafikkommandon, kamera, new Skärmposition(0 * 16, 0 * 16), new Skärmyta(16, 16))
            };

            var omgivningensBrickor = new Bricka[] {
                new Bricka(grafikkommandon, kamera, new Skärmposition(1 * 16, 0), new Skärmyta(16, 16)),
                new Bricka(grafikkommandon, kamera, new Skärmposition(2 * 16, 0), new Skärmyta(16, 16))
            };

            spelvärld.MiljöGrafik = new Brickfält(grafikkommandon, kamera, positionskonverterare, omgivningensBrickor, kartbredd, karta.Indexar);

            spelvärld.Fienden = new List<Fiende>
            {
                new Fiende {
                    Position = new Spelvärldsposition(5, 5),
                    Grafik = new Bricka(grafikkommandon, kamera, new Skärmposition(3*16, 0), new Skärmyta(16, 16)),
                    Riktningsgenerator = new SekvensFörflyttning(new List<Spelvärldsposition>
                    {
                        new Spelvärldsposition(1, 0),
                        new Spelvärldsposition(0, 1),
                        new Spelvärldsposition(-1, 0),
                        new Spelvärldsposition(0, -1)
                    }, new SekvensFörflyttning.SlumpmässigIndexgenerator())
                }
            };
        }

        private void Kör()
        {
            _fönster.Kör(60.0, 60.0);
        }
    }
}
