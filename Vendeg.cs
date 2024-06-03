using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikeletPanzio
{
    internal class Vendeg
    {
        string id;
        string name;
        DateTime szulIdo;
        string email;
        bool vip;


        public Vendeg(string id, string name, DateTime szulIdo, string email, bool vip)
        {
            this.id = GeneraltID(name);
            this.name = name;
            this.szulIdo = szulIdo;
            this.email = email;
            this.vip = vip;
        }

        public string Name { get => name; set => name = value; }
        public DateTime SzulIdo { get => szulIdo; set => szulIdo = value; }
        public string Email { get => email; set => email = value; }
        public bool Vip { get => vip; set => vip = value; }
        public string Id { get => id; set => id = value; }

        private string GeneraltID(string name)
        {
            return $"{name}:{DateTime.Now.ToString("yyyyMMdd")}";
        }
    }
}
