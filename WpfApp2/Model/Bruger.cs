using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTema.Model
{
    public class Bruger
    {

        private int _brugerID;
        private string _brugerNavn;
        private string _adgangskode;       
        private string _brugerType;
        //det er en test
        public int Bruger_ID {
            get => _brugerID;
            set => _brugerID = value;  }
        public string Bruger_Navn {
            get=>_brugerNavn;
            set=>_brugerNavn=value; }

        public string Bruger_Adgangskode {
            get => _adgangskode;
            set => _adgangskode = value;  }

        public string Bruger_Type {
            get => _brugerType;
            set => _brugerType = value;
        }

    }
}
