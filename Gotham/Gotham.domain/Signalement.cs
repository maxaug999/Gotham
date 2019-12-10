namespace Gotham.domain
{
    public class Signalement : Entity
    {
        public string Nature { get; set; }
        public string Secteur { get; set; }
        public string Heure { get; set; }
        public string Commentaires { get; set; }
    }
}