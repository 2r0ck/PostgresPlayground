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
            return _goodsRepository.GetRange(0, 100).Select(x => new GoodViewModel(x)).ToList();
        }

        // GET: api/Goods/5
        [HttpGet("{id}", Name = "Get")]
        public GoodViewModel Get(int id)
        {
            return new GoodViewModel(_goodsRepository.Get(id));
        }

        // POST: api/Goods
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Goods/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
