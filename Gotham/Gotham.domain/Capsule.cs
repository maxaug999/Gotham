using System;

namespace Gotham.domain
{
    public class Capsule : Entity
    {
        public string Titre { get; set; }
        public string Texte { get; set; }
        public bool Publié { get; set; }
        public Uri VideoUrl { get; set; }
    }
}