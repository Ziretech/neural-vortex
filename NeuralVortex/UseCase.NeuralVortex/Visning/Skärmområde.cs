namespace UseCase.NeuralVortex.Visning
{
    public class Skärmområde : Område
    {
        public Skärmområde(int vänster, int botten, int höger, int topp) : base(vänster, botten, höger, topp) { }

        public Skärmområde(Skärmposition position, Skärmyta yta) : base(position, yta) { }

        public Skärmområde(Skärmyta yta) : base(new Position(0, 0), yta) { }

        public new Skärmposition Position => new Skärmposition(base.Position);

        public new Skärmyta Yta => new Skärmyta(base.Yta);
    }

}
