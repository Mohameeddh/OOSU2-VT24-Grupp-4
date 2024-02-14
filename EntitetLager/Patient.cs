using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitetLager
{
    public class Patient
    {
        public string Namn { get; set; }
        public int PersonNummer { get; set; }
        public string Adress { get; set; }
        public int TelefonNummer { get; set; }
        public string Epost { get; set; }
        public int PatientNummerId { get; set; }

        public List<LäkarBesök> LäkarbesökLista = new List<LäkarBesök>();

        public Patient(string namn, int personNummer, string adress, int telefonNummer, string epost, int patientNummer)
        {
            this.Namn = namn;
            this.PersonNummer = personNummer;
            this.Adress = adress;
            this.TelefonNummer = telefonNummer;
            this.Epost = epost;
            this.PatientNummerId = patientNummer;
        }



    }
}
