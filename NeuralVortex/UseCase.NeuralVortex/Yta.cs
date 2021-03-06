﻿namespace UseCase.NeuralVortex
{
    public class Yta
    {
        private readonly int _bredd;
        private readonly int _höjd;

        public Yta(int bredd, int höjd)
        {
            _bredd = bredd;
            _höjd = höjd;
        }

        public Yta(Yta yta)
        {
            _bredd = yta.Bredd;
            _höjd = yta.Höjd;
        }

        public int Bredd => _bredd;
        public int Höjd => _höjd;

        public override string ToString()
        {
            return $"{_bredd}x{_höjd}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var position = (Yta)obj;
            return position.Bredd.Equals(Bredd) && position.Höjd.Equals(Höjd);
        }

        public override int GetHashCode()
        {
            return Bredd ^ Höjd;
        }

        public Yta MultiplicerasMed(Yta yta)
        {
            return new Yta(_bredd * yta._bredd, _höjd * yta._höjd);
        }
    }
}