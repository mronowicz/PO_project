using PO_project; // Załóżmy, że PO_project to przestrzeń nazw, w której znajdują się klasy Samochod, Pracownik, Mechanik, Kierownik, Klient

class Klient
{
    public string Imie { get; set; }
    public string Email { get; set; }
    public string Telefon { get; set; }
    public Samochod Samochod { get; set; }

    public Klient(string imie, string email, string telefon, Samochod samochod)
    {
        Imie = imie;
        Email = email;
        Telefon = telefon;
        Samochod = samochod;
    }
}
