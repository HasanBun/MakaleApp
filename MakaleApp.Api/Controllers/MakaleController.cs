using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakaleApp.Api.ApiRepository;
using MakaleApp.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace MakaleApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MakaleController : ControllerBase
    {
        readonly MakaleRepository _makaleRepository;
        private readonly IMemoryCache _memoryCache;
        readonly ILogger<MakaleController> _logger;

        public MakaleController(MakaleRepository makaleRepository,IMemoryCache memoryCache, ILogger<MakaleController> logger)
        {
            _makaleRepository = makaleRepository;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        // GET: api/Makale
        [HttpGet]
        public IEnumerable<Makale> GetMakaleData()
        {
            const string cacheKey = "AllData";
            if (!_memoryCache.TryGetValue(cacheKey, out List<Makale> response))
            {
                response = _makaleRepository.GetAllData().ToList();

                var cacheExpirationOptions =
                    new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(30),
                        Priority = CacheItemPriority.Normal
                    };
                _memoryCache.Set(cacheKey, response, cacheExpirationOptions);
            }
            return response;
        }

        // GET: api/Makale/5
        [HttpGet("{id}", Name = "Get")]
        public Makale GetMakale(int id)
        {
            var makale = _makaleRepository.GetDataById(id);

            return makale;
        }

        // POST: api/Makale
        [HttpPost]
        public string PostMakale([FromBody] Makale value)
        {
            try
            {
                _logger.LogInformation("{0} adlı kullanıcının makalesi ekleniyor.", HttpContext.User.Identity.Name);
                _makaleRepository.Insert(value);
                _logger.LogInformation("{0} adlı kullanıcı makale ekledi.", HttpContext.User.Identity.Name);
                return "Başarılı";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.Message;
            }
        }

        // PUT: api/Makale/5
        [HttpPut("{id}")]
        public string MakaleUpdate(Makale value)
        {
            try
            {
                _makaleRepository.Update(value);
                return "Başarılı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void MakaleDelete(int id)
        {
            _makaleRepository.DeleteById(id);
        }
    }
}
