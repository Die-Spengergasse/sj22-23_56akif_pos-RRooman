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
            get { return Zuname?[..3]?.ToUpper() ?? ""; }
        }

        public decimal? Nettogehalt { get 
            { return (_bruttoGehalt ?? 0) *0.8M; }
        }
    }
}
