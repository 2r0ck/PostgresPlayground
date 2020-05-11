using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresPlayGround.Db.Models
{
    public class Good
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ColorId { get; set; }

        [ForeignKey("ColorId")]
        public virtual GoodColor Color {get;set;}

        public decimal Price { get; set; }
    }
}
