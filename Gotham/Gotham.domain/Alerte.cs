using System;
using System.Collections.Generic;
using System.Text;

namespace Gotham.domain
{
    public class Alerte : Entity
    {
        public string Nature { get; set; }
        public string Secteur { get; set; }
        public string Risque { get; set; }
        public string Ressource { get; set; }
        public string Conseil { get; set; }
        public bool Publié { get; set; }
    }
}
