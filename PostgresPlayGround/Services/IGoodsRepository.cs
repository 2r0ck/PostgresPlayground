using PostgresPlayGround.Db.Models;
using System.Collections.Generic;

namespace PostgresPlayGround.Services
{
    public interface IGoodsRepository
    {
        public Good Get(int id);
        public IEnumerable<Good> GetRange(int minId, int maxId);
        void AddOrUpdate(ViewModels.GoodViewModel value);
        bool Delete(int id);
        IEnumerable<Good> GetAll();
        IEnumerable<Good> GetByName(string name);
    }
}