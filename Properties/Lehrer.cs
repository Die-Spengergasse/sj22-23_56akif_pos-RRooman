using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    internal class Lehrer
    {
        private decimal? _bruttoGehalt;

        public string? Zuname { get; set; }
        public string Vorname { set; get; } = string.Empty;

        public decimal? Bruttogehalt
        {
            get { return _bruttoGehalt; }
            set { _bruttoGehalt ??= value; }
        }
        public string? Kuerzel { 
            get { return Zuname?[..3]?.ToUpper() ?? string.Empty; }             //[2..3]->von Stelle 2 bis 3; [..^3]->bis 3 Stellen vor Ende 
        }

        public decimal? Nettogehalt { get 
            { return (_bruttoGehalt ?? 0) *0.8M; }
        }

        //public decimal? Nettogehalt => (_bruttoGehalt ?? 0) * 0.8M;           //alternativer Lambdaausdruck
    }
}
