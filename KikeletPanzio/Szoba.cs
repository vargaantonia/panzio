using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikeletPanzio
{
    internal class Szoba
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
    }
    internal class VendegAdat
    {
        public string id;
        public string name;
        DateTime szulIdo;
        public string email;
        public bool vip;

        public VendegAdat(string id, string name, DateTime szulIdo, string email, bool vip)
        {
            this.id = id;
            this.name = name;
            this.szulIdo = szulIdo;
            this.email = email;
            this.vip = vip;
        }


        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime SzulIdo { get => szulIdo; set => szulIdo = value; }
        public string Email { get => email; set => email = value; }
        public bool Vip { get => vip; set => vip = value; }

        public string IdGeneral(string name) 
        {
            return $"{name}_{DateTime.Now.ToString("yyyy.MM.dd")}";
        }
    }
}