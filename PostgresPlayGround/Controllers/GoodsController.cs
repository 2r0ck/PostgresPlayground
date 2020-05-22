using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostgresPlayGround.Services;
using PostgresPlayGround.ViewModels;

namespace PostgresPlayGround.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly IGoodsRepository _goodsRepository;

        public GoodsController(IGoodsRepository goodsRepository)
        {
            this._goodsRepository = goodsRepository;
        }
        // GET: api/Goods
        [HttpGet]
        public IEnumerable<GoodViewModel> Get()
        {
            return _goodsRepository.GetAll().Select(x => new GoodViewModel(x)).ToList();
        }

        // GET: api/Goods/5
        [HttpGet("{id}", Name = "Get")]
        public GoodViewModel Get(int id)
        {
            return new GoodViewModel(_goodsRepository.Get(id));
        }

        // POST: api/Goods
        [HttpPost]
        public void Post([FromBody] GoodViewModel value)
        {
            if (value != null)
            {
                _goodsRepository.AddOrUpdate(value);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _goodsRepository.Delete(id);
        }

        [HttpGet]
        [Route("search")]
        public IEnumerable<GoodViewModel> GetByName(string name)
        {
            return _goodsRepository.GetByName(name).Select(x => new GoodViewModel(x)).ToList();
        }
    }
}
