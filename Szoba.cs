using System;

namespace KikeletPanzio
{
    public class Szoba
    {
        public int szobaSzam;
        public int feroHely;
        public int ejszakaAr;

        public Szoba(int szobaSzam, int feroHely, int ejszakaAr)
        {
            this.szobaSzam = szobaSzam;
            this.feroHely = feroHely;
            this.ejszakaAr = ejszakaAr;
        }

        public int SzobaSzam { get => szobaSzam; set => szobaSzam = value; }
        public int FeroHely { get => feroHely; set => feroHely = value; }
        public int EjszakaAr { get => ejszakaAr; set => ejszakaAr = value; }

        public Szoba() { }

        public override string ToString()
        {
            return $"Szobaszám: {szobaSzam}, Férőhely: {feroHely}, Ár (Ft/Fő/Éj): {ejszakaAr}";
        }
    }
    public class VendegAdat
    {
        public string id;
        public string name;
        DateTime szulIdo;
        public string email;
        public bool vip;


        public VendegAdat(string name, DateTime szulIdo, string email, bool vip )
        {
            id = GenerateAzonosito(name);
            this.name = name;
            this.szulIdo = szulIdo;
            this.email = email;
            this.vip = vip;
        }



        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime SzulIdo { get => szulIdo; set => szulIdo = value; }
        public string Email { get => email; set => email = value; }
        public bool Vip { get => vip; }

        private string GenerateAzonosito(string nev)
        {
            return $"{nev}_{DateTime.Now:yyyyMMddHHmmss}";
        }

    }

    public class Foglalas
    {
        private Szoba szoba;
        private VendegAdat vendeg;
        private DateTime erkezesDatum;
        private DateTime tavozasDatum;
        private int foszam;
        private double osszkoltseg;

        public Szoba Szoba { get => szoba; set => szoba = value; }
        public VendegAdat Vendeg { get => vendeg; set => vendeg = value; }
        public DateTime ErkezesDatum { get => erkezesDatum; set => erkezesDatum = value; }
        public DateTime TavozasDatum { get => tavozasDatum; set => tavozasDatum = value; }
        public int Foszam { get => foszam; set => foszam = value; }
        public double Osszkoltseg { get => osszkoltseg; set => osszkoltseg = value; }
    }
}
  