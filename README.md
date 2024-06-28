Mechanik - System Zarządzania Klientami i Pracownikami

1. Opis:
Program mechanik to prosty system do zarządzania klientami i pracownikami w warsztacie samochodowym. Umożliwia dodawanie, edytowanie, przeglądanie oraz usuwanie danych klientów oraz dodawanie pracowników do bazy danych.

Funkcje:
Pokaz klientow
Wyświetla listę wszystkich klientów w systemie wraz z informacjami o ich samochodach.

Dodaj klienta
Pozwala na dodanie nowego klienta do systemu, w tym informacji o imieniu, emailu, telefonie oraz szczegółów dotyczących ich samochodu.

Edytuj klienta
Umożliwia edycję danych istniejącego klienta, w tym informacji o imieniu, emailu, telefonie oraz szczegółów samochodu.

Usun klienta
Usuwa wybranego klienta z systemu.

Garaz
Wyświetla szczegóły dotyczące wszystkich samochodów klientów.

Dodaj pracownika
Pozwala na dodanie nowego pracownika (mechanika lub kierownika) do bazy danych.

Pokaz pracownikow
Wyświetla listę wszystkich pracowników w systemie.

Wyjdz
Zamyka program.

2. Klasy i atrybuty
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
Relacje
Dziedziczenie:
Mechanik i Kierownik dziedziczą po Pracownik.
Agregacja:
Program zawiera listy klienci i pracownicy.
Klient ma atrybut Samochod.

3. Diagram UML

+-----------------+
|    Program      |
+-----------------+
| - klienci       |
| - pracownicy    |
| - listaKlientowSciezka |
| - listaPracownikowSciezka |
+-----------------+
| + Main()        |
| + PokazKlientow()|
| + DodajKlienta() |
| + EdytujKlienta()|
| + UsunKlienta()  |
| + Garaz()        |
| + PokazPracownikow() |
| + DodajPracownikaInnaNazwa() |
| + DodajMechanikaDoListy() |
| + DodajKierownikaDoListy() |
| + ZapiszPracownikowDoPliku() |
| + Prompt(message : string) : string |
| + WyswietlRok(message : string) : int |
| + IndeksKlienta() : int |
| + sprawdzEmail(email : string) : bool |
| + sprawdzNumerTelefonu(telefon : string) : bool |
+-----------------+

+-----------------+     +-------------+
|     Klient      |<----|   Samochod  |
+-----------------+     +-------------+
| - Imie          |     | - Marka     |
| - Email         |     | - Model     |
| - Telefon       |     | - RokProdukcji |
| - Samochod      |     | - NumerRejestracyjny |
+-----------------+     +-------------+
| + Klient(imie, email, telefon, samochod) |
+-----------------+     | + Samochod(marka, model, rokProdukcji, numerRejestracyjny) |
                        +-------------+

+-----------------+
|   Pracownik     |
+-----------------+
| - Nazwisko      |
+-----------------+
| + Rodzaj() : string |
| + DodajDoListy() |
+-----------------+
        ^
        |
+-----------------+       +-----------------+
|    Mechanik     |       |    Kierownik    |
+-----------------+       +-----------------+
| + Mechanik(nazwisko) |  | + Kierownik(nazwisko) |
+-----------------+       +-----------------+

4. W podanym kodzie w języku C# wykorzystano następujące technologie i biblioteki:

C#: Język programowania, w którym napisany jest cały kod. C# jest językiem programowania stworzonym przez Microsoft, który jest często używany do tworzenia aplikacji na platformę .NET.
.NET Framework: Wykorzystano .NET Framework do tworzenia aplikacji desktopowych w Windows Forms. .NET Framework jest platformą programistyczną firmy Microsoft, która zapewnia wiele bibliotek i narzędzi do tworzenia aplikacji na platformę Windows.
Windows Forms: Wykorzystano Windows Forms do tworzenia interfejsu użytkownika (GUI) w aplikacji desktopowej. Windows Forms jest technologią do tworzenia aplikacji desktopowych w systemie Windows, umożliwiającą tworzenie interfejsów użytkownika za pomocą formularzy i kontrolek.
System.IO: Wykorzystano bibliotekę System.IO do operacji wejścia/wyjścia plików. Ta biblioteka umożliwia operacje związane z plikami, takie jak odczyt, zapis, tworzenie plików itp.
System.Linq: Wykorzystano bibliotekę System.Linq do operacji na kolekcjach danych. Biblioteka ta zapewnia wiele metod rozszerzeń do operacji na kolekcjach, takich jak Select, Where, Any, itp.
Windows Console: Początkowo kod był napisany w konsoli, ale w odpowiedzi na Twoje prośby, został przekształcony w interfejs użytkownika w Windows Forms.

4. Instrukcje użytkowania:
Po uruchomieniu programu wybierz odpowiednią opcję, wpisując numer lub literę wybranej funkcji.
W przypadku dodawania lub edycji klienta, podawaj poprawne dane (np. email musi zawierać @ i należeć do jednej z dozwolonych domen).
Numery klientów i pracowników wprowadzaj zgodnie z wyświetlanymi listami.

5. Autorzy
Program stworzony przez Marcin Ronowicz oraz Krzysztof Paździór.

Wymagania
System operacyjny: Windows, Linux, macOS
Wymagany runtime: .NET Core 3.1 lub nowszy
Kontakt
W razie problemów lub pytań prosimy o kontakt:
Email: roniasty@gmail.com, pazdzior.krzysztof01@gmail.com

Historia zmian
v1.0 (22.06.2024)
Pierwsza wersja programu mechanik
