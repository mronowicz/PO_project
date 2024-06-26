using PO_project; // Załóżmy, że PO_project to przestrzeń nazw, w której znajdują się klasy Samochod, Pracownik, Mechanik, Kierownik, Klient

interface IPracownik
{
    string Nazwisko { get; }
    string Rodzaj { get; }
}
