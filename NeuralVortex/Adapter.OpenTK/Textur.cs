namespace Adapter.OpenTK
{
    class Textur
    {
        private readonly IBild _bild;
        private readonly int _id;
        private readonly IGrafikkommandon _gl;

        public Textur(IGrafikkommandon grafikkommandon, IBild bild)
        {
            _gl = grafikkommandon;
            _bild = bild;

            _id = _gl.GenereraTextur();
            _gl.VäljAktivTextur(_id);
            _gl.VäljNärmasteFärgVidTexturförminskning();
            _gl.VäljNärmasteFärgVidTexturförstoring();
            _bild.LåsBilddata32ARGB().DefinieraTexturbild();
            _bild.FrigörBilddata();
        }

        public void Aktivera()
        {
            _gl.VäljAktivTextur(_id);
            _gl.VäljTexturmatris();
            _gl.NollställMatris();
            _gl.Skalningsmatris(1.0 / _bild.Bredd, 1.0 / _bild.Höjd);
            _gl.VäljModellmatris();
        }
    }
}
