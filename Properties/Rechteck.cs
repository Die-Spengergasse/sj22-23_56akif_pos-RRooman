using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    internal class Rechteck
    {
        private int _laenge, _breite;

        public int Laenge
        {
            get { return _laenge; }
            set { _laenge = value > 0 ? value : throw new ArgumentException("Ungültige Länge"); }
        }

        public int Breite
        {
            get { return _breite; }
            set { _breite = value > 0 ? value : throw new ArgumentException("Ungültige Breite"); }
        }

        public int Flaeche => _laenge * _breite;
    }
}
