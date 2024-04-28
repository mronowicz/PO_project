using System;
using System.Collections.Generic;

class Program
{
    static List<Klient> klienci = new List<Klient>();

    static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("mechanik");
            Console.WriteLine("1. Pokaz klientow");
            Console.WriteLine("2. Dodaj klienta");
            Console.WriteLine("3. Edytuj klienta");
            Console.WriteLine("4. Usun klienta");
            Console.WriteLine("5. Wyjdz");

            switch (Console.ReadLine())
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
                    exit = true;
                    break;
            }
        }
    }

    static void PokazKlientow()
    {
        Console.Clear();
        Console.WriteLine("lista klientow:");

        if (klienci.Count == 0)
        {
            Console.WriteLine("nic tu nie ma");
        }
        else
        {
            for (int i = 0; i < klienci.Count; i++)
            {
                Console.WriteLine("{0}. {1} ({2})", i + 1, klienci[i].Name, klienci[i].Email);
            }
        }

        Console.WriteLine();
        Console.WriteLine("kliknij cos");
        Console.ReadKey();
    }

    static void DodajKlienta()
    {
        Console.Clear();
        Console.WriteLine("dodaj klienta");

        Console.Write("imie: ");
        string imie = Console.ReadLine();

        Console.Write("mail: ");
        string email = Console.ReadLine();

        klienci.Add(new Klient(imie, email));

        Console.WriteLine("dodano");
        Console.WriteLine();
        Console.WriteLine("kliknij cos");
        Console.ReadKey();
    }

    static void EdytujKlienta()
    {
        Console.Clear();
        Console.WriteLine("zmien dane klienta");

        Console.Write("numer klienta do edycji ");
        int index = int.Parse(Console.ReadLine()) - 1;

        Console.Write("imie: ");
        string name = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        klienci[index] = new Klient(name, email);

        Console.WriteLine("Contact edited successfully!");
        Console.WriteLine();
        Console.WriteLine("kliknij cos");
        Console.ReadKey();
    }

    static void UsunKlienta()
    {
        Console.Clear();
        Console.WriteLine("usun klienta);

        Console.Write("numer klienta do usuniecia");
        int index = int.Parse(Console.ReadLine()) - 1;

        klienci.RemoveAt(index);

        Console.WriteLine("usunieto");
        Console.WriteLine();
        Console.WriteLine("kliknij cos");
        Console.ReadKey();
    }
}

class Klient
{
    public string Name { get; set; }
    public string Email { get; set; }

    public Klient(string name, string email)
    {
        Name = name;
        Email = email;
    }
}
