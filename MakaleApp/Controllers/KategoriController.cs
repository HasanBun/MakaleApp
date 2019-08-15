using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakaleApp.Data.Entity;
using MakaleApp.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MakaleApp.Controllers
{
    public class KategoriController : Controller
    {
        // GET: api/Kategori
        public IActionResult GetKategori()
        {
            string url = Environment.GetEnvironmentVariable("ApiUrl");
            url += "api/kategori/GetKategoriData";
            HttpApiHelper helper = new HttpApiHelper(url, "GET");
            string response = helper.GetResponse();

            IEnumerable<Kategori> kategori = JsonConvert.DeserializeObject<IEnumerable<Kategori>>(response);

            return View(kategori);
        }

        // GET: api/Kategori/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Kategori
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Kategori/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        public void Delete(int id)
        {
        }
    }
}
