using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.AI;
using UseCase.NeuralVortex.Kontroll;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Spec
{
    [TestFixture]
    public class FlyttaVarelserSpec
    {
        [Test]
        public void Flytta_huvudkaraktären_uppåt()
        {
            var spelvärld = new SpelvärldMock { Huvudkaraktär = new Huvudkaraktär { Position = new Spelvärldsposition(0, 0) } };
            var flyttaVarelser = new FlyttaVarelser(spelvärld, null);

            flyttaVarelser.Flytta(Tangent.Upp);

            Assert.That(spelvärld.Huvudkaraktär.Position.Y, Is.EqualTo(1));
        }

        [Test]
        public void Flytta_huvudkaraktären_nedåt()
        {
            var spelvärld = new SpelvärldMock { Huvudkaraktär = new Huvudkaraktär { Position = new Spelvärldsposition(2, 3) } };
            var flyttaVarelser = new FlyttaVarelser(spelvärld, null);

            flyttaVarelser.Flytta(Tangent.Ner);

            Assert.That(spelvärld.Huvudkaraktär.Position.Y, Is.EqualTo(2));
        }

        [Test]
        public void Flytta_huvudkaraktären_vänster()
        {
            var spelvärld = new SpelvärldMock { Huvudkaraktär = new Huvudkaraktär { Position = new Spelvärldsposition(2, 3) } };
            var flyttaVarelser = new FlyttaVarelser(spelvärld, null);

            flyttaVarelser.Flytta(Tangent.Vänster);

            Assert.That(spelvärld.Huvudkaraktär.Position.X, Is.EqualTo(1));
        }

        [Test]
        public void Flytta_huvudkaraktären_höger()
        {
            var spelvärld = new SpelvärldMock { Huvudkaraktär = new Huvudkaraktär { Position = new Spelvärldsposition(2, 13) } };
            var flyttaVarelser = new FlyttaVarelser(spelvärld, null);

            flyttaVarelser.Flytta(Tangent.Höger);

            Assert.That(spelvärld.Huvudkaraktär.Position.X, Is.EqualTo(3));
        }

        [Test]
        public void Hindrar_högerförflyttning_till_ruta_med_hinder()
        {
            var spelvärld = new SpelvärldMock { Huvudkaraktär = new Huvudkaraktär { Position = new Spelvärldsposition(1, 13) } };
            var hinderkarta = new HinderkartaMock(new Spelvärldsposition[] { new Spelvärldsposition(2, 13) });
            var flyttaVarelser = new FlyttaVarelser(spelvärld, hinderkarta);

            flyttaVarelser.Flytta(Tangent.Höger);

            Assert.That(spelvärld.Huvudkaraktär.Position.X, Is.EqualTo(1));
        }

        [Test]
        public void Hindrar_vänsterförflyttning_till_ruta_med_hinder()
        {
            var spelvärld = new SpelvärldMock { Huvudkaraktär = new Huvudkaraktär { Position = new Spelvärldsposition(1, 13) } };
            var hinderkarta = new HinderkartaMock(new Spelvärldsposition[] { new Spelvärldsposition(0, 13) });
            var flyttaVarelser = new FlyttaVarelser(spelvärld, hinderkarta);

            flyttaVarelser.Flytta(Tangent.Vänster);

            Assert.That(spelvärld.Huvudkaraktär.Position.X, Is.EqualTo(1));
        }

        [Test]
        public void Hindrar_uppförflyttning_till_ruta_med_hinder()
        {
            var spelvärld = new SpelvärldMock { Huvudkaraktär = new Huvudkaraktär { Position = new Spelvärldsposition(13, 1) } };
            var hinderkarta = new HinderkartaMock(new Spelvärldsposition[] { new Spelvärldsposition(13, 2) });
            var flyttaVarelser = new FlyttaVarelser(spelvärld, hinderkarta);

            flyttaVarelser.Flytta(Tangent.Upp);

            Assert.That(spelvärld.Huvudkaraktär.Position.Y, Is.EqualTo(1));
        }

        [Test]
        public void Hindrar_nerförflyttning_till_ruta_med_hinder()
        {
            var spelvärld = new SpelvärldMock { Huvudkaraktär = new Huvudkaraktär { Position = new Spelvärldsposition(13, 1) } };
            var hinderkarta = new HinderkartaMock(new Spelvärldsposition[] { new Spelvärldsposition(13, 0) });
            var flyttaVarelser = new FlyttaVarelser(spelvärld, hinderkarta);

            flyttaVarelser.Flytta(Tangent.Ner);

            Assert.That(spelvärld.Huvudkaraktär.Position.Y, Is.EqualTo(1));
        }

        [Test]
        public void Flytta_fienden_uppåt()
        {
            var spelvärld = new SpelvärldMock
            {
                Fienden = new List<Fiende>
                {
                    new Fiende { Position = new Spelvärldsposition(0, 0), Riktningsgenerator = new SekvensFörflyttning(new List<Spelvärldsposition>{ new Spelvärldsposition(0, 1) }, new SekvensFörflyttning.IterativIndexgenerator())}
                }
            };
            var flyttaVarelser = new FlyttaVarelser(spelvärld, null);

            flyttaVarelser.Flytta(Tangent.Ner);

            Assert.That(spelvärld.Fienden.First().Position.Y, Is.EqualTo(1));
        }

        [Test]
        public void Flytta_fienden_upp_till_höger()
        {
            var spelvärld = new SpelvärldMock
            {
                Fienden = new List<Fiende>
                {
                    new Fiende { Position = new Spelvärldsposition(0, 0), Riktningsgenerator = new SekvensFörflyttning(new List<Spelvärldsposition> { new Spelvärldsposition(0, 1), new Spelvärldsposition(1, 0) }, new SekvensFörflyttning.IterativIndexgenerator()) }
                }
            };
            var flyttaVarelser = new FlyttaVarelser(spelvärld, null);

            flyttaVarelser.Flytta(Tangent.Höger);
            flyttaVarelser.Flytta(Tangent.Vänster);

            Assert.That(spelvärld.Fienden.First().Position, Is.EqualTo(new Spelvärldsposition(1, 1)));
        }
    }
}
