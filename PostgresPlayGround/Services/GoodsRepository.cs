using Microsoft.EntityFrameworkCore;
using PostgresPlayGround.Db;
using PostgresPlayGround.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresPlayGround.Services
{
    public class GoodsRepository : IGoodsRepository
    {
        private readonly PlaygroundContext _db_Context;

        public GoodsRepository(PlaygroundContext db_context)
        {
            _db_Context = db_context;
        }

        public Good Get(int id)
        {
            return _db_Context.Goods.Include(x=>x.Color).FirstOrDefault(x => x.Id == id);

        }

        public IEnumerable<Good> GetRange(int minId, int maxId)
        {
            return _db_Context.Goods.Include(x => x.Color).Where(x => x.Id >= minId && x.Id < maxId);
        }
    }
}
