using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Klient> klienci = new List<Klient>();

    static void Main()
    {
        string choice;
        do
        {
            Console.Clear();
            Console.WriteLine("mechanik");
            Console.WriteLine("1. Pokaz klientow");
            Console.WriteLine("2. Dodaj klienta");
            Console.WriteLine("3. Edytuj klienta");
            Console.WriteLine("4. Usun klienta");
            Console.WriteLine("5. Wyjdz");

            choice = Console.ReadLine();
            switch (choice)
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
            }
        } while (choice != "5");
    }

    static void PokazKlientow()
    {
        Console.Clear();
        Console.WriteLine("lista klientow:");

        if (!klienci.Any())
        {
            Console.WriteLine("nic tu nie ma");
        }
        else
        {
            foreach (var (klient, index) in klienci.Select((value, i) => (value, i)))
            {
                Console.WriteLine($"{index + 1}. {klient.Imie} ({klient.Email}, {klient.Telefon})");
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
        var telefon = Prompt("telefon: ");
        var samochod = Prompt("Samochod: ")

        klienci.Add(new Klient(imie, email, telefon));

        Console.WriteLine("dodano\n");
        Console.ReadKey();
    }

    static void EdytujKlienta()
    {
        PokazKlientow();

        var index = GetClientIndex();

        var imie = Prompt("imie: ");
        var email = Prompt("Email: ");
        var telefon = Prompt("telefon: ");

        klienci[index] = new Klient(imie, email, telefon);

        Console.WriteLine("Contact edited successfully!\n");
        Console.ReadKey();
    }

    static void UsunKlienta()
    {
        PokazKlientow();

        var index = GetClientIndex();

        klienci.RemoveAt(index);

        Console.WriteLine("usunieto\n");
        Console.ReadKey();
    }

    static string Prompt(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }

    static int GetClientIndex()
    {
        int index;

        do
        {
            Console.Write("numer klienta: ");

            if (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > klienci.Count)
                Console.WriteLine("Invalid number. Try again.");

        } while (index < 1 || index > klienci.Count);

        return index - 1;
    }
}

class Klient
{
    public string Imie { get; set; }
    public string Email { get; set; }
    public string Telefon { get; set; }
    public string Samochod { get; set; }

    public Klient(string imie, string email, string telefon)
    {
        Imie = imie;
        Email = email;
        Telefon = telefon;
    }
}