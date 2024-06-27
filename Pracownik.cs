namespace PO_project
{
    public abstract class Pracownik
    {
        public string Nazwisko { get; set; }

        protected Pracownik(string nazwisko)
        {
            Nazwisko = nazwisko;
        }

        public abstract string Rodzaj();
    }
}
