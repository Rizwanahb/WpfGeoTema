using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTema.Model
{
    public class Fødselsrate_Rang
    {
      
            private int _rang;
            private string _landNavn;
            private decimal _data;
            private string _verdensdelNavn;

            public int LandId
            {
                get; set;
            }

            public int VerdenId
            { get; set; }

            public string Land_Navn
            {
                get => _landNavn;
                set => _landNavn = value;
            }
            public string Verdensdel_Navn
            {
                get => _verdensdelNavn;
                set => _verdensdelNavn = value;
            }
            public int Rang
            {
                get => _rang;
                set => _rang = value;
            }
            public decimal Fødselsrate
            {
                get => _data;
                set => _data = value;
            }
        }
    }


