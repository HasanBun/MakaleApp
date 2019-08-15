using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakaleApp.Api.ApiRepository;
using MakaleApp.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MakaleApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        readonly KategoriRepository _kategoriRepository;

        public KategoriController(KategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }
        // GET: api/Kategori
        [HttpGet]
        public IEnumerable<Kategori> GetKategoriData()
        {
            return _kategoriRepository.GetAllData();
        }

        // GET: api/Kategori/5
        [HttpGet("{id}")]
        public Kategori GetKategori(int id)
        {
            return _kategoriRepository.GetDataById(id);
        }

        // POST: api/Kategori
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Kategori/5
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
