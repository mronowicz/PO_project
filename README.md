Mechanik - System Zarządzania Klientami i Pracownikami
1. Opis
Program mechanik to prosty system do zarządzania klientami i pracownikami w warsztacie samochodowym. Umożliwia dodawanie, edytowanie, przeglądanie oraz usuwanie danych klientów oraz dodawanie pracowników do bazy danych.

1.1 Opis projektu
PO_project to przykładowa aplikacja napisana w C#, demonstrująca podstawowe koncepcje programowania obiektowego takie jak hermetyzacja, polimorfizm, interfejsy oraz dziedziczenie.

Wymagania
.NET Framework 4.8
Instalacja
Sklonuj repozytorium:
git clone https://github.com/mronowicz/PO_project.git
Otwórz rozwiązanie w Visual Studio.
Zbuduj projekt i uruchom aplikację.
Struktura projektu
App.config - Plik konfiguracyjny aplikacji.
IPracownik.cs - Definicja interfejsu IPracownik.
Kierownik.cs - Klasa reprezentująca kierownika.
Klient.cs - Klasa reprezentująca klienta.
Mechanik.cs - Klasa reprezentująca mechanika.
Pracownik.cs - Klasa bazowa dla pracowników.
Program.cs - Główny punkt wejścia do aplikacji.
Samochod.cs - Klasa reprezentująca samochód.
Properties/AssemblyInfo.cs - Informacje o wersji i metadane asemblera.

Przykłady użycia:
Aby uruchomić aplikację, wykonaj następujące kroki:

Zbuduj projekt w Visual Studio.
Uruchom aplikację, wybierając opcję "Start" lub naciskając F5.

2. Funkcje
Pokaz klientow: Wyświetla listę wszystkich klientów w systemie wraz z informacjami o ich samochodach.
Dodaj klienta: Pozwala na dodanie nowego klienta do systemu, w tym informacji o imieniu, emailu, telefonie oraz szczegółów dotyczących ich samochodu.
Edytuj klienta: Umożliwia edycję danych istniejącego klienta, w tym informacji o imieniu, emailu, telefonie oraz szczegółów samochodu.
Usun klienta: Usuwa wybranego klienta z systemu.
Garaz: Wyświetla szczegóły dotyczące wszystkich samochodów klientów.
Dodaj pracownika: Pozwala na dodanie nowego pracownika (mechanika lub kierownika) do bazy danych.
Pokaz pracownikow: Wyświetla listę wszystkich pracowników w systemie.
Wyjdz: Zamyka program.
3. Instrukcje użytkowania
Po uruchomieniu programu wybierz odpowiednią opcję, wpisując numer lub literę wybranej funkcji.
W przypadku dodawania lub edycji klienta, podawaj poprawne dane (np. email musi zawierać @ i należeć do jednej z dozwolonych domen).
Numery klientów i pracowników wprowadzaj zgodnie z wyświetlanymi listami.

4. Klasy i atrybuty

Program
Atrybuty:

klienci : List<Klient>
pracownicy : List<Pracownik>
listaKlientowSciezka : string
listaPracownikowSciezka : string

Metody:
Main(args : string[])
PokazKlientow()
DodajKlienta()
EdytujKlienta()
UsunKlienta()
Garaz()
PokazPracownikow()
DodajPracownikaInnaNazwa()
DodajMechanikaDoListy()
DodajKierownikaDoListy()
ZapiszPracownikowDoPliku()
Prompt(message : string) : string
WyswietlRok(message : string) : int
IndeksKlienta() : int
sprawdzEmail(email : string) : bool
sprawdzNumerTelefonu(telefon : string) : bool

Klient
Atrybuty:
Imie : string
Email : string
Telefon : string
Samochod : Samochod

Metody:
Konstruktor Klient(imie : string, email : string, telefon : string, samochod : Samochod)
Samochod

Atrybuty:
Marka : string
Model : string
RokProdukcji : int
NumerRejestracyjny : string

Metody:
Konstruktor Samochod(marka : string, model : string, rokProdukcji : int, numerRejestracyjny : string)
Pracownik

Atrybuty:
Nazwisko : string

Metody:
Rodzaj() : string
DodajDoListy()
Mechanik (dziedziczy po Pracownik)

Metody:
Konstruktor Mechanik(nazwisko : string)
Kierownik (dziedziczy po Pracownik)

Metody:
Konstruktor Kierownik(nazwisko : string)

Relacje:
Dziedziczenie: Mechanik i Kierownik dziedziczą po Pracownik.
Agregacja: Program zawiera listy klienci i pracownicy.
Kompozycja: Klient ma atrybut Samochod.

5. Diagram UML
+------------------------+
|        Program         |
+------------------------+
| - klienci              |
| - pracownicy           |
| - listaKlientowSciezka |
| - listaPracownikowSciezka |
+------------------------+
| + Main(args : string[]) |
| + PokazKlientow()      |
| + DodajKlienta()       |
| + EdytujKlienta()      |
| + UsunKlienta()        |
| + Garaz()              |
| + PokazPracownikow()   |
| + DodajPracownikaInnaNazwa() |
| + DodajMechanikaDoListy() |
| + DodajKierownikaDoListy() |
| + ZapiszPracownikowDoPliku() |
| + Prompt(message : string) : string |
| + WyswietlRok(message : string) : int |
| + IndeksKlienta() : int |
| + sprawdzEmail(email : string) : bool |
| + sprawdzNumerTelefonu(telefon : string) : bool |
+------------------------+

+------------------------+
|         Klient         |
+------------------------+
| - Imie                 |
| - Email                |
| - Telefon              |
| - Samochod             |
+------------------------+
| + Klient(imie, email, telefon, samochod) |
+------------------------+

+------------------------+
|       Samochod         |
+------------------------+
| - Marka                |
| - Model                |
| - RokProdukcji         |
| - NumerRejestracyjny   |
+------------------------+
| + Samochod(marka, model, rokProdukcji, numerRejestracyjny) |
+------------------------+

+------------------------+
|       Pracownik        |
+------------------------+
| - Nazwisko             |
+------------------------+
| + Rodzaj() : string    |
| + DodajDoListy()       |
+------------------------+
        ^
        |
+------------------------+      +------------------------+
|       Mechanik        |      |       Kierownik        |
+------------------------+      +------------------------+
| + Mechanik(nazwisko)  |      | + Kierownik(nazwisko)  |
+------------------------+      +------------------------+

6. Omówienie kodu

Hermetyzacja
Hermetyzacja (enkapsulacja) polega na ukrywaniu szczegółów implementacyjnych danej klasy i udostępnianiu jedynie niezbędnych interfejsów do komunikacji z innymi klasami.

Przykład:
Plik: Samochod.cs

public class Samochod
{

    private string marka;
    private string model;
    private int rokProdukcji;

    public string Marka
    {
        get { return marka; }
        set { marka = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public int RokProdukcji
    {
        get { return rokProdukcji; }
        set { rokProdukcji = value; }
    }
}
W powyższym przykładzie zmienne marka, model oraz rokProdukcji są prywatne, a dostęp do nich jest kontrolowany przez właściwości publiczne.

Polimorfizm
Polimorfizm umożliwia różnym klasom reagowanie na te same metody w różny sposób. W C# polimorfizm jest realizowany m.in. przez dziedziczenie i implementację interfejsów.

Przykład:
Plik: Pracownik.cs

csharp
Skopiuj kod
public virtual void WykonajPrace()
{

    Console.WriteLine("Pracownik wykonuje pracę.");
    
}
Plik: Kierownik.cs

public override void WykonajPrace()
{

    Console.WriteLine("Kierownik zarządza pracą.");
    
}
W powyższym przykładzie metoda WykonajPrace jest zdefiniowana w klasie bazowej Pracownik, a następnie jest nadpisana w klasie Kierownik.

Interfejsy
Interfejsy definiują kontrakty, które muszą być implementowane przez klasy. W projekcie jest używany interfejs IPracownik.

Przykład:
Plik: IPracownik.cs

public interface IPracownik
{

    void WykonajPrace();
}
Plik: Pracownik.cs

public class Pracownik : IPracownik
{

    public virtual void WykonajPrace()
    {
        Console.WriteLine("Pracownik wykonuje pracę.");
    }
}
W powyższym przykładzie klasa Pracownik implementuje interfejs IPracownik i definiuje metodę WykonajPrace.

Dziedziczenie
Dziedziczenie pozwala na tworzenie nowych klas na podstawie istniejących, co umożliwia ponowne wykorzystanie kodu.

Przykład:
Plik: Pracownik.cs

public class Pracownik
{

    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Stanowisko { get; set; }

    public virtual void WykonajPrace()
    {
        Console.WriteLine("Pracownik wykonuje pracę.");
    }
}

Plik: Kierownik.cs

public class Kierownik : Pracownik
{

    public override void WykonajPrace()
    {
        Console.WriteLine("Kierownik zarządza pracą.");
    }
}
W powyższym przykładzie klasa Kierownik dziedziczy po klasie Pracownik, co oznacza, że Kierownik posiada wszystkie właściwości i metody Pracownik.

7. Wykorzystane technologie i biblioteki
C#: Język programowania, w którym napisany jest cały kod.
.NET Framework: Platforma programistyczna używana do tworzenia aplikacji.
Windows Forms: Technologia do tworzenia interfejsu użytkownika (GUI) w aplikacji desktopowej (GUI przeniesione do innego repozytorium, oto link:[https://github.com/mronowicz/PO_projekt_GUI]).
System.IO: Biblioteka do operacji wejścia/wyjścia plików.
System.Linq: Biblioteka do operacji na kolekcjach danych.
Windows Console: Projekt konsolowy.

8. Autorzy
Program stworzony przez Marcin Ronowicz oraz Krzysztof Paździór.


Wymagania
System operacyjny: Windows, Linux, macOS
Wymagany runtime: .NET Core 3.1 lub nowszy

Kontakt
W razie problemów lub pytań prosimy o kontakt:
Email: roniasty@gmail.com, pazdzior.krzysztof01@gmail.com

Historia zmian
v1.0 (05.07.2024): Pierwsza wersja programu mechanik
