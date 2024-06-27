using PO_project; 

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
