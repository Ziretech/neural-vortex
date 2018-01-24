using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex
{
    public class Spelvärldsområde : Område
    {
        //public Spelvärldsområde(Spelvärldsposition position, Spelvärldsyta yta) : base(position, yta) { }

        public Spelvärldsområde(int vänster, int botten, int höger, int topp) : base(vänster, botten, höger, topp) { }
    }
}
