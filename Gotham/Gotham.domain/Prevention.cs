using System;
using System.Collections.Generic;
using System.Text;

namespace Gotham.domain
{
    public class Prevention : Entity
    {
        public string Titre { get; set; }
        public string Texte { get; set; }
        public string Mois { get; set; }
        public string Publié { get; set; }
    }
}
