using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitetLager
{
    public class Läkemedel
    {
        public DateTime UtskrivningsDatum { get; set; }
        public string MedicinNamn { get; set; }
        public string Dosering { get; set; }

        public Läkemedel(DateTime utskrivningsDatum, string medicinNamn, string dosering)
        {
            this.UtskrivningsDatum = utskrivningsDatum;
            this.MedicinNamn = medicinNamn;
            this.Dosering = dosering;
        }
    }
}
