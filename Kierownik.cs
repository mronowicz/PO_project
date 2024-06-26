namespace PO_project
{
    public class Kierownik : Pracownik
    {
        public Kierownik(string nazwisko) : base(nazwisko)
        {
        }

        public override string Rodzaj()
        {
            return "Kierownik";
        }

        public void DodajDoListy()
        {
            Program.pracownicy.Add(this);
        }
    }
}
