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
        private Karta SkapaKarta()
        {
            const int kartbredd = 16;
            const int karthöjd = 16;

            var kartritare = new Kartritare(new Spelvärldsyta(kartbredd, karthöjd));
            kartritare.SkapaYta(1, new Spelvärldsområde(1, 1, 8, 8));
            kartritare.Skapa(2, new Spelvärldsposition(9, 4));
            kartritare.SkapaYta(1, new Spelvärldsområde(10, 2, 15, 10));
            var karta = kartritare.Karta;
            karta.Indexar[56 + 16] = 3;
            karta.Indexar[4 + 4 * 16] = 4;
            karta.Indexar[7 + 3 * 16] = 4;
            karta.Indexar[13 + 7 * 16] = 4;
            karta.Indexar[13 + 8 * 16] = 5;
            return karta;
        }

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

            var ucVisaSpelvärld = new VisaSpelvärld(spelvärld, positionskonverterare);

            var karta = SkapaKarta();
            var hinderlista = new[] { 0 };
            var hinderkarta = karta.SkapaHinderkarta(hinderlista);

            var ucFlyttaVarelser = new FlyttaVarelser(spelvärld, hinderkarta);
            var ucUtdelaSkada = new UtdelaSkada(spelvärld);
            var ucDödaKritisktSkadade = new DödaKritisktSkadade(spelvärld);
            var ucUppdateraSpelvärld = new UppdateraSpelvärld(ucFlyttaVarelser, ucUtdelaSkada, ucDödaKritisktSkadade);
            var openTKHanterare = new GrafikHändelser(grafikkommandon, tileset, _fönster, ucVisaSpelvärld, kamera);
            var kontrollhändelser = new KontrollHändelser(ucUppdateraSpelvärld, _fönster);

            _fönster.Laddare(openTKHanterare);
            _fönster.StorleksÄndrare(openTKHanterare);
            _fönster.Uppdaterare(openTKHanterare);
            _fönster.Visare(openTKHanterare);
            _fönster.Tangentbordsmottagare(kontrollhändelser);

            var radioaktivInsektBricka = new Bricka(grafikkommandon, kamera, new Skärmposition(5 * 16, 0), new Skärmyta(16, 16));
            var tomBricka = new Bricka(grafikkommandon, kamera, new Skärmposition(15 * 16, 15 * 16), new Skärmyta(16, 16));
            var takBricka = new Bricka(grafikkommandon, kamera, new Skärmposition(2 * 16, 1 * 16), new Skärmyta(16, 16));
            var kabel1Bricka = new Bricka(grafikkommandon, kamera, new Skärmposition(3 * 16, 1 * 16), new Skärmyta(16, 16));
            var kabel2Bricka = new Bricka(grafikkommandon, kamera, new Skärmposition(4 * 16, 1 * 16), new Skärmyta(16, 16));
            var takMedRevaBricka = new Bricka(grafikkommandon, kamera, new Skärmposition(1 * 16, 1 * 16), new Skärmyta(16, 16));
            var ammoBricka = new Bricka(grafikkommandon, kamera, new Skärmposition(0 * 16, 1 * 16), new Skärmyta(16, 16));
            var huvudkaraktärBricka = new Bricka(grafikkommandon, kamera, new Skärmposition(0 * 16, 0 * 16), new Skärmyta(16, 16));
            var medicinBricka = new Bricka(grafikkommandon, kamera, new Skärmposition(3 * 16, 2 * 16), new Skärmyta(16, 16));
            var paradisBricka = new Bricka(grafikkommandon, kamera, new Skärmposition(3 * 16, 3 * 16), new Skärmyta(16, 16));

            spelvärld.Huvudkaraktär = new Huvudkaraktär(2)
            {
                Position = new Spelvärldsposition(1, 1),
                Grafik = huvudkaraktärBricka
            };

            var omgivningensBrickor = new Bricka[] {
                tomBricka,
                takBricka,
                kabel1Bricka,
                kabel2Bricka,
                takMedRevaBricka,
                paradisBricka
            };

            spelvärld.MiljöGrafik = new Brickfält(kamera, positionskonverterare, omgivningensBrickor, karta.Bredd, karta.Indexar);

            var slumpgenerator = new Random();
            var väderstrecken = new List<Spelvärldsposition>
            {
                new Spelvärldsposition(1, 0),
                new Spelvärldsposition(0, 1),
                new Spelvärldsposition(-1, 0),
                new Spelvärldsposition(0, -1)
            };

            var irraRunt = new SekvensFörflyttning(väderstrecken, new SekvensFörflyttning.SlumpmässigIndexgenerator(slumpgenerator));

            spelvärld.Fienden = new List<Fiende>
            {
                new Fiende {
                    Position = new Spelvärldsposition(5, 5),
                    Grafik = radioaktivInsektBricka,
                    Riktningsgenerator = irraRunt
                },
                new Fiende {
                    Position = new Spelvärldsposition(13, 5),
                    Grafik = radioaktivInsektBricka,
                    Riktningsgenerator = irraRunt
                }
            };
        }

        private void Kör()
        {
            _fönster.Kör(60.0, 60.0);
        }
    }
}
