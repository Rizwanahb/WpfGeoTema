using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTema.Model
{
    public class Land
    {
        private int LandID;
        private string LandNavn;

        public int Land_ID {
            get =>LandID;
            set => LandID=value; }
        public string Land_Navn
        { get=>LandNavn;
            set=>LandNavn=value; }

       
    }
}
