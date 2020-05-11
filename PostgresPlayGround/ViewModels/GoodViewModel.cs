using PostgresPlayGround.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresPlayGround.ViewModels
{
    public class GoodViewModel : ViewModelBase<Good>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public decimal Price { get; set; }

        public GoodViewModel()
        {

        }
        public GoodViewModel(Good good)
        {
            FromDb(good);
        }

        protected override void FromDb(Good data)
        {
            if (data != null)
            {
                Id = data.Id;
                Name = data.Name;
                Color = data.Color?.Descr;
                Price = data.Price;
            }
        }
    }
}
