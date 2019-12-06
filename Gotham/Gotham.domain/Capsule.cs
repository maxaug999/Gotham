namespace Gotham.domain
{
    public class Capsule : Entity
    {
        public string Titre { get; set; }
        public string Texte { get; set; }
        public string Lien { get; set; }
        public bool Publie { get; set; }
        public string VideoUrl { get; set; }
    }
}