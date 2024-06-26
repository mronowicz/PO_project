namespace PO_project
{
    public class Mechanik : Pracownik
    {
        public Mechanik(string nazwisko) : base(nazwisko)
        {
        }

        public override string Rodzaj()
        {
            return "Mechanik";
        }

        public void DodajDoListy()
        {
            Program.pracownicy.Add(this);
        }
    }
}
