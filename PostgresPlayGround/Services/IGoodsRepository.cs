using PostgresPlayGround.Db.Models;
using System.Collections.Generic;

namespace PostgresPlayGround.Services
{
    public interface IGoodsRepository
    {
        public Good Get(int id);
        public IEnumerable<Good> GetRange(int minId, int maxId);
    }
}