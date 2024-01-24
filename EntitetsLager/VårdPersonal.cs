using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitetsLager
{
    public class VårdPersonal
    {
        public int AnställningsNummer { get; set; }
        public string Namn { get; set; }
        public string YrkesRoll { get; set; }
        public int Lösenord {  get; set; }
        public string Specialisering { get; set; }
    }
}
