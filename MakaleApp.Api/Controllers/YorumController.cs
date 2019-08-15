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
    public class YorumController : ControllerBase
    {
        readonly YorumRepository _yorumRepository;

        public YorumController(YorumRepository yorumRepository)
        {
            _yorumRepository = yorumRepository;
        }
        // GET: api/Yorum
        [HttpGet("{id}")]
        public IEnumerable<Yorum> GetAllYorum(int id)
        {
            return _yorumRepository.GetAllData().Where(x => x.MakaleId == id).ToList();
        }

        // GET: api/Yorum/5
        [HttpGet("{id}")]
        public Yorum GetYorum(int id)
        {
            return _yorumRepository.GetDataById(id);
        }

        // POST: api/Yorum
        [HttpPost]
        public string PostYorum([FromBody] Yorum value)
        {
            try
            {
                _yorumRepository.Insert(value);
                return "Başarılı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT: api/Yorum/5
        [HttpPut("{id}")]
        public string YorumUpdate([FromBody] Yorum value)
        {
            try
            {
                _yorumRepository.Update(value);
                return "Başarılı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void YorumDelete(int id)
        {
            _yorumRepository.DeleteById(id);
        }
    }
}
