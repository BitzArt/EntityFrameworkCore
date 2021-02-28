using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitzArt.EntityFrameworkCore.Models
{
    public class EntityCreated<TKey> : BaseEntity<TKey>
    {
        [Column("CreatedOn")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; }

        [Column("CreatedBy")]
        public Guid CreatedBy { get; set; }
    }
}
