using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTema.Model
{
    public class Rang
    {
        private int _rangId;
        private int _landId;
        private int _rang;
        //private int _statid;
        private decimal _fødselsrate;

        public int Rang_ID
        {
            get => _rangId;
            set => _rangId = value;
        }

        public int Land_ID
        {
            get => _landId;
            set => _landId = value;
        }
        public int Rang_Nummer
        {
            get => _rang;
            set => _rang = value;
        }
        //public int Statistik_id
        //{
        //    get => _statid;
        //    set => _statid = value;
        //}
        public decimal Fødselsrate
        {
            get => _fødselsrate;
            set => _fødselsrate = value;
        }
    }

}