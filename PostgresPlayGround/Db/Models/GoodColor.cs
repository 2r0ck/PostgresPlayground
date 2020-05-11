using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresPlayGround.Db.Models
{
    public class GoodColor
    {
        [Key]
        public int Id { get; set; }

        public string Descr { get; set; }
    }
}
