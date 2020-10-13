using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTema.Model
{
    public class Verdensdel
    {
        private int _verdensdelId;
        private string _verdensdelNavn;


        public int V_ID {
            get=>_verdensdelId;
            set => _verdensdelId= value; }
        public string Verdensdel_Navn {
            get =>_verdensdelNavn;
            set=>_verdensdelNavn=value; }       
    }
}
