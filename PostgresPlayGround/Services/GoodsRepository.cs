using Microsoft.EntityFrameworkCore;
using PostgresPlayGround.Db;
using PostgresPlayGround.Db.Models;
using PostgresPlayGround.ViewModels;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PostgresPlayGround.Services
{
    public class GoodsRepository : IGoodsRepository
    {
        private readonly PlaygroundContext _db_Context;

        public GoodsRepository(PlaygroundContext db_context)
        {
            _db_Context = db_context;
        }

        public bool Delete(int id)
        {
            var db_val = _db_Context.Goods.FirstOrDefault(x => x.Id == id);
            if (db_val != null)
            {
                _db_Context.Goods.Remove(db_val);
                _db_Context.ChangeTracker.DetectChanges();
                _db_Context.SaveChanges();
                return true;
            }
            return false;
        }


        public void AddOrUpdate([NotNull] GoodViewModel value)
        {
            var db_val = _db_Context.Goods.FirstOrDefault(x => x.Id == value.Id);
            if (db_val == null)
            {
                db_val = new Good();
                _db_Context.Add(db_val);
            }
            //set props
            db_val.Name = value.Name;


            _db_Context.ChangeTracker.DetectChanges();
            _db_Context.SaveChanges();
        }

        public Good Get(int id)
        {
            return _db_Context.Goods.Include(x => x.Color).FirstOrDefault(x => x.Id == id);

        }

        public IEnumerable<Good> GetRange(int minId, int maxId)
        {
            return _db_Context.Goods.Include(x => x.Color).Where(x => x.Id >= minId && x.Id < maxId).ToList();
        }

        public IEnumerable<Good> GetAll()
        {
            return _db_Context.Goods.Include(x => x.Color).ToList();
        }

        public IEnumerable<Good> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return new List<Good>();
            }
            return _db_Context.Goods.Include(x => x.Color).Where(x=>x.Name.Contains(name)).ToList();

        }
    }
}
