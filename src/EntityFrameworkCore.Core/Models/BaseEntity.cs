using System.ComponentModel.DataAnnotations.Schema;

namespace BitzArt.EntityFrameworkCore.Models
{
    public class BaseEntity<TKey>
    {
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        TKey Id { get; set; }
    }
}
