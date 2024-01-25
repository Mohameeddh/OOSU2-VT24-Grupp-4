using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitetLager
{
    public class Läkare
    {
        public int AnställningsNummer { get; set; }
        public string Namn { get; set; }
        public string YrkesRoll { get; set; }
        public int Lösenord { get; set; }
        public string Specialisering { get; set; }

        public Läkare(int anställningsNummer, string namn, string yrkesRoll, int lösenord, string specialicering)
        {
            this.AnställningsNummer = anställningsNummer;
            this.Namn = namn;
            this.YrkesRoll = yrkesRoll;
            this.Lösenord = lösenord;
            this.Specialisering = specialicering;
        }
    }
}
