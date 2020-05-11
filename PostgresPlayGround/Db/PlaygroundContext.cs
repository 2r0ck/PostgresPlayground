using Microsoft.EntityFrameworkCore;
using PostgresPlayGround.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresPlayGround.Db
{
    public class PlaygroundContext :DbContext
    {

        public PlaygroundContext(DbContextOptions options) :base(options)
        {

        }

        public DbSet<GoodColor> Colors { get; set; }
        public DbSet<Good> Goods { get; set; }
    }
}
