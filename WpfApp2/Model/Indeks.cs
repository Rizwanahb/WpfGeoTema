using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTema.Model
{
  
    class Indeks
    {
        private int _IndeksId;
        private int _VId;

        private int _landId;
        public int Indeks_ID
        {
            get => _IndeksId;
            set => _IndeksId = value;
        }
        public int Land_ID {
            get => _landId;
            set => _landId = value;
        }
        public int V_ID {
            get => _VId;
            set => _VId = value;  }
        

    }
}
