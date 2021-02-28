using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitzArt.EntityFrameworkCore.Models
{
    public class EntityUpdated<TKey> : EntityCreated<TKey>
    {
        [Column("UpdatedOn")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedOn { get; set; }

        [Column("UpdatedBy")]
        public Guid UpdatedBy { get; set; }
    }
}
