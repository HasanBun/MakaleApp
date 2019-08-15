using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakaleApp.Data.Entity;
using MakaleApp.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;


namespace MakaleApp.Controllers
{
    public class MakaleController : Controller
    {
        // GET: api/Makale
        public IActionResult MakaleHomePage()
        {
            string url = Environment.GetEnvironmentVariable("ApiUrl");
            url += "api/makale/GetMakaleData";
            HttpApiHelper helper = new HttpApiHelper(url, "GET");
            string response = helper.GetResponse();
            ViewBag.User = HttpContext.User.Identity.Name;
            IEnumerable<Makale> makale = JsonConvert.DeserializeObject<IEnumerable<Makale>>(response);
            return View(makale);
        }
        public IActionResult Arama(string makaletext)
        {
            string url = Environment.GetEnvironmentVariable("ApiUrl");
            url += "api/makale/GetMakaleData";
            HttpApiHelper helper = new HttpApiHelper(url, "GET");
            string response = helper.GetResponse();
            ViewBag.User = HttpContext.User.Identity.Name;
            IEnumerable<Makale> makale = JsonConvert.DeserializeObject<IEnumerable<Makale>>(response);
            makale = makale.Where(x => x.Icerik.Contains(makaletext));
            return View(makale);
        }
        public IActionResult MakaleGet(int id)
        {
            string url = Environment.GetEnvironmentVariable("ApiUrl");
            url += "api/makale/GetMakale/" + id;
            HttpApiHelper helper = new HttpApiHelper(url, "GET");
            string response = helper.GetResponse();

            Makale makale = JsonConvert.DeserializeObject<Makale>(response);

            ViewBag.User = HttpContext.User.Identity.Name;
            url = Environment.GetEnvironmentVariable("ApiUrl");
            url += "api/yorum/GetAllYorum/" + id;
            HttpApiHelper helperyorum = new HttpApiHelper(url, "GET");
            response = helperyorum.GetResponse();

            IEnumerable<Yorum> yorum = JsonConvert.DeserializeObject<IEnumerable<Yorum>>(response);
            return View(Tuple.Create(yorum,makale));
        }

        // POST: api/Makale
        public IActionResult MakaleAdd()
        {
            string url = Environment.GetEnvironmentVariable("ApiUrl");
            url += "api/kategori/GetKategoriData/";
            HttpApiHelper helper = new HttpApiHelper(url, "GET");
            //string response = helper.GetResponseWithModel(JsonConvert.SerializeObject(value));
            string response = helper.GetResponse();
            IEnumerable<Kategori> kategori = JsonConvert.DeserializeObject<IEnumerable<Kategori>>(response);
            ViewBag.Kategori = kategori.Select(k => new SelectListItem
            {
                Text = k.KategoriAdi,
                Value = k.KategoriId.ToString()
            }).ToList();

            return View();
        }

        [HttpPost, ActionName("MakaleAdd")]
        public IActionResult MakaleAdd(Makale makale)
        {
            makale.CreatedUserId = HttpContext.User.Identity.Name;
            string url = Environment.GetEnvironmentVariable("ApiUrl");
            url += "api/makale/PostMakale/";
            HttpApiHelper helper = new HttpApiHelper(url, "POST");
            string response = helper.GetResponseWithModel(JsonConvert.SerializeObject(makale));
            //Makale makaleadd = JsonConvert.DeserializeObject<Makale>(response);
            return RedirectToAction("MakaleHomePage");
        }

        // PUT: api/Makale/5
        public IActionResult MakaleUpdate(int id)
        {
            string url = Environment.GetEnvironmentVariable("ApiUrl");
            url += "api/makale/GetMakale/" + id;
            HttpApiHelper helper = new HttpApiHelper(url, "GET");
            string response = helper.GetResponse();

            Makale makale = JsonConvert.DeserializeObject<Makale>(response);
            return View(makale);
        }
        [HttpPost, ActionName("MakaleUpdate")]
        public IActionResult MakaleUpdaten(Makale makale)
        {
            makale.UpdatedUserId = HttpContext.User.Identity.Name;
            string url = Environment.GetEnvironmentVariable("ApiUrl");
            url += "api/makale/PostMakale/";
            HttpApiHelper helper = new HttpApiHelper(url, "POST");
            string response = helper.GetResponseWithModel(JsonConvert.SerializeObject(makale));
            //Makale makaleadd = JsonConvert.DeserializeObject<Makale>(response);
            return RedirectToAction("MakaleHomePage");
        }

        // DELETE: api/ApiWithActions/5
        public IActionResult Delete(int id)
        {
            string url = Environment.GetEnvironmentVariable("ApiUrl");
            url += "api/makale/MakaleDelete/" + id;
            HttpApiHelper helper = new HttpApiHelper(url, "Delete");
            string response = helper.GetResponse();
            return RedirectToAction("MakaleHomePage");
        }
    }
}
