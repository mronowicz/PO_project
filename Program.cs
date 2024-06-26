using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static List<Klient> klienci = new List<Klient>();
    static List<Pracownik> pracownicy = new List<Pracownik>();
    static string listaKlientowSciezka = "ListaKlientow.txt";

    static void Main()
    {
        if (!File.Exists(listaKlientowSciezka))
        {
            File.Create(listaKlientowSciezka).Close();
        }

        string menu;
        do
        {
            Console.Clear();
            Console.WriteLine("mechanik");
            Console.WriteLine("1. Pokaz klientow");
            Console.WriteLine("2. Dodaj klienta");
            Console.WriteLine("3. Edytuj klienta");
            Console.WriteLine("4. Usun klienta");
            Console.WriteLine("5. Garaz");
            Console.WriteLine("6. Dodaj pracownika");
            Console.WriteLine("7. Pokaz pracownikow");
            Console.WriteLine("8. Wyjdz");

            menu = Console.ReadLine();
            switch (menu)
            {
                case "1":
                    PokazKlientow();
                    break;
                case "2":
                    DodajKlienta();
                    break;
                case "3":
                    EdytujKlienta();
                    break;
                case "4":
                    UsunKlienta();
                    break;
                case "5":
                    Garaz();
                    break;
                case "6":
                    DodajPracownika();
                    break;
                case "7":
                    PokazPracownikow();
                    break;
            }
        } while (menu != "8");
    }

    static void PokazKlientow()
    {
        Console.Clear();
        Console.WriteLine("lista klientow:");

        if (!File.Exists(listaKlientowSciezka))
        {
            Console.WriteLine("Plik ListaKlientow.txt nie istnieje.");
            Console.ReadKey();
            return;
        }

        klienci.Clear();

        string[] lines = File.ReadAllLines(listaKlientowSciezka);

        foreach (string line in lines)
        {
            string[] parts = line.Split(';');

            string imie = parts[0];
            string email = parts[1];
            string telefon = parts[2];
            string marka = parts[3];
            string model = parts[4];
            int rokProdukcji = int.Parse(parts[5]);
            string numerRejestracyjny = parts[6];

            Samochod samochod = new Samochod(marka, model, rokProdukcji, numerRejestracyjny);
            klienci.Add(new Klient(imie, email, telefon, samochod));
        }

        if (!klienci.Any())
        {
            Console.WriteLine("nic tu nie ma");
        }
        else
        {
            foreach (var (klient, index) in klienci.Select((value, i) => (value, i)))
            {
                var samochod = klient.Samochod;
                Console.WriteLine($"{index + 1}. {klient.Imie} ({klient.Email}, {klient.Telefon}) - Samochod: {samochod.Marka} {samochod.Model} ({samochod.RokProdukcji}), {samochod.NumerRejestracyjny}");
            }
        }

        Console.ReadKey();
    }

    static void DodajKlienta()
    {
        Console.Clear();
        Console.WriteLine("dodaj klienta");

        var imie = Prompt("imie: ");
        var email = Prompt("mail: ");
        while (!sprawdzEmail(email))
        {
            Console.WriteLine("Nieprawidłowy adres e-mail. Spróbuj ponownie.");
            email = Prompt("mail: ");
        }
        var telefon = Prompt("telefon: ");
        while (!sprawdzNumerTelefonu(telefon))
        {
            Console.WriteLine("Nieprawidłowy numer telefonu. Numer telefonu powinien składać się wyłącznie z cyfr i mieścić się w zakresie od 7 do 14 znaków. Spróbuj ponownie.");
            telefon = Prompt("telefon: ");
        }

        Console.WriteLine("dodaj samochod klienta");
        var marka = Prompt("marka: ");
        var model = Prompt("model: ");
        var rokProdukcji = WyswietlRok("rok produkcji: ");
        var numerRejestracyjny = Prompt("numer rejestracyjny: ");

        var samochod = new Samochod(marka, model, rokProdukcji, numerRejestracyjny);

        using (StreamWriter wpisz = File.AppendText(listaKlientowSciezka))
        {
            wpisz.WriteLine($"{imie};{email};{telefon};{marka};{model};{rokProdukcji};{numerRejestracyjny}");
        }

        klienci.Add(new Klient(imie, email, telefon, samochod));

        Console.WriteLine("dodano, nacisnij enter aby wrócic do menu\n");
        Console.ReadKey();
    }
    static bool sprawdzEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        if (!email.Contains("@"))
        {
            return false;
        }

        string[] dozwoloneDomeny = { "gmail.com", "interia.pl", "wp.pl", "onet.pl", "o2.pl", "gazeta.pl" };

        string domena = email.Split('@')[1];
        if (!dozwoloneDomeny.Any(d => domena.EndsWith(d)))
        {
            return false;
        }

        return true;
    }

    static bool sprawdzNumerTelefonu(string telefon)
    {
        if (string.IsNullOrWhiteSpace(telefon))
        {
            return false;
        }

        if (telefon.Length < 7 || telefon.Length > 14)
        {
            return false;
        }

        foreach (char c in telefon)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }

        return true;
    }

    static void EdytujKlienta()
    {
        PokazKlientow();

        var index = IndeksKlienta();

        var imie = Prompt("imie: ");
        var email = Prompt("Email: ");
        while (!sprawdzEmail(email))
        {
            Console.WriteLine("Nieprawidłowy adres e-mail. Spróbuj ponownie.");
            email = Prompt("Email: ");
        }

        var telefon = Prompt("telefon: ");
        while (!sprawdzNumerTelefonu(telefon))
        {
            Console.WriteLine("Nieprawidłowy numer telefonu. Numer telefonu powinien składać się wyłącznie z cyfr i mieścić się w zakresie od 7 do 14 znaków. Spróbuj ponownie.");
            telefon = Prompt("telefon: ");
        }

        Console.WriteLine("edytuj samochod klienta");
        var marka = Prompt("marka: ");
        var model = Prompt("model: ");
        var rokProdukcji = WyswietlRok("rok produkcji: ");
        var numerRejestracyjny = Prompt("numer rejestracyjny: ");

        var samochod = new Samochod(marka, model, rokProdukcji, numerRejestracyjny);

        klienci[index] = new Klient(imie, email, telefon, samochod);

        Console.WriteLine("klient zaktualizowany \n");
        Console.ReadKey();
    }

    static void UsunKlienta()
    {
        Console.Clear();
        Console.WriteLine("Usuń klienta");

        if (!klienci.Any())
        {
            Console.WriteLine("Brak klientów do usunięcia.");
            Console.ReadKey();
            return;
        }

        PokazKlientow();

        int index;
        do
        {
            Console.WriteLine("Podaj numer klienta do usunięcia (0 aby wrócić do menu): ");
            var input = Console.ReadLine();

            if (input == "0")
            {
                Console.WriteLine("Anulowano usuwanie klienta.");
                Console.ReadKey();
                return;
            }

            if (!int.TryParse(input, out index) || index < 1 || index > klienci.Count)
            {
                Console.WriteLine("Zły numer, podaj numer z listy.");
                index = -1;
            }

        } while (index == -1);

        klienci.RemoveAt(index - 1);

        Console.WriteLine("Usunięto klienta.");
        Console.ReadKey();
    }

    static void Garaz()
    {
        Console.Clear();
        Console.WriteLine("Dane samochodu:");
        foreach (var klient in klienci)
        {
            var samochod = klient.Samochod;
            Console.WriteLine($"Marka: {samochod.Marka}");
            Console.WriteLine($"Model: {samochod.Model}");
            Console.WriteLine($"Rok produkcji: {samochod.RokProdukcji}");
            Console.WriteLine($"Numer rejestracyjny: {samochod.NumerRejestracyjny}");
            Console.WriteLine();
        }

        Console.WriteLine("naciśnij Enter, aby wrócić do menu");
        Console.ReadLine();
    }

    static void PokazPracownikow()
    {
        Console.Clear();
        Console.WriteLine("Lista pracowników:");

        if (!pracownicy.Any())
        {
            Console.WriteLine("Nie ma żadnych pracowników.");
        }
        else
        {
            foreach (var (pracownik, index) in pracownicy.Select((value, i) => (value, i)))
            {
                Console.WriteLine($"{index + 1}. {pracownik.Nazwisko} ({pracownik.GetType().Name})");
            }
        }

        Console.ReadKey();
    }

    static string Prompt(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }

    static int WyswietlRok(string message)
    {
        int year;
        string input;
        do
        {
            Console.Write(message);
            input = Console.ReadLine();
            if (!int.TryParse(input, out year) || input.Length != 4 || year < 1986 || year > 2024)
            {
                Console.WriteLine("Wprowadź prawidłowy rok produkcji");
            }
        } while (!int.TryParse(input, out year) || input.Length != 4 || year < 1986 || year > 2024);

        return year;
    }

    static int IndeksKlienta()
    {
        int index;

        do
        {
            Console.Write("numer klienta: ");

            if (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > klienci.Count)
                Console.WriteLine("zły numer, podaj numer z listy");

        } while (index < 1 || index > klienci.Count);

        return index - 1;
    }

    static void DodajPracownika()
    {
        Console.Clear();
        Console.WriteLine("Wybierz rodzaj pracownika:");
        Console.WriteLine("1. Mechanik");
        Console.WriteLine("2. Kierownik");

        string wybor = Console.ReadLine();
        switch (wybor)
        {
            case "1":
                DodajMechanika();
                break;
            case "2":
                DodajKierownika();
                break;
            default:
                Console.WriteLine("Nieprawidłowy wybór.");
                break;
        }

        Console.WriteLine("Naciśnij Enter, aby wrócić do menu");
        Console.ReadLine();
    }

    static void DodajMechanika()
    {
        var nazwisko = Prompt("Nazwisko mechanika: ");
        pracownicy.Add(new Mechanik(nazwisko));
        Console.WriteLine("Dodano mechanika.");
    }

    static void DodajKierownika()
    {
        var nazwisko = Prompt("Nazwisko kierownika: ");
        pracownicy.Add(new Kierownik(nazwisko));
        Console.WriteLine("Dodano kierownika.");
    }

    class Pracownik
    {
        public string Nazwisko { get; set; }

        public Pracownik(string nazwisko)
        {
            Nazwisko = nazwisko;
        }
    }

    class Mechanik : Pracownik
    {
        public Mechanik(string nazwisko) : base(nazwisko)
        {
        }
    }

    class Kierownik : Pracownik
    {
        public Kierownik(string nazwisko) : base(nazwisko)
        {
        }
    }

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

    class Samochod
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public int RokProdukcji { get; set; }
        public string NumerRejestracyjny { get; set; }

        public Samochod(string marka, string model, int rokProdukcji, string numerRejestracyjny)
        {
            Marka = marka;
            Model = model;
            RokProdukcji = rokProdukcji;
            NumerRejestracyjny = numerRejestracyjny;
        }
    }
}