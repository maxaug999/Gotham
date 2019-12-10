using System.ComponentModel.DataAnnotations.Schema;

namespace Gotham.domain
{
    public abstract class Entity
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}