namespace Gotham.domain
{
    public class Nouvelle : Entity
    {
        public string Titre { get; set; }
        public string Texte { get; set; }
        public string Lien { get; set; }
        public int Status { get; set; }
    }
}