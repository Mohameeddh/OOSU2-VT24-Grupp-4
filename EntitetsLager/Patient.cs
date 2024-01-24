using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitetsLager
{
    public class Patient
    {
        public string Namn { get; set; }
        public int PersonNummer { get; set; }
        public string Adress {  get; set; } 
        public string TelefonNummer { get; set; }
        public string Epost { get; set; }
        public int PatientNummer { get; set; }

        public LäkarBesök LäkarbesökLista;

        public Patient(string namn, int personNummer, string adress, string telefonNummer, string epost, int patientNummer)
        {
            this.Namn = namn;
            this.PersonNummer = personNummer;
            this.Adress = adress;
            this.TelefonNummer = telefonNummer;
            this.Epost = epost;
            this.PatientNummer = patientNummer;
        }

        public void BokaNyttBesök(int besöksNummer, DateTime datum, LäkarBesök besöksSyfte, VårdPersonal anställningsNummer)
        {
            LäkarBesök NyttLäkarBesök = new LäkarBesök(besöksNummer, this, datum, besöksSyfte, anställningsNummer);
        }

    }
}
