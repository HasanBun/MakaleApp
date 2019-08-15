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
    public class YorumController : Controller
    {

        public IActionResult YorumAdd()
        {
            return View();
        }

        // POST: api/Yorum
        [HttpPost, ActionName("YorumAdd")]
        public IActionResult YorumAdd([FromBody] Yorum yorum)
        {
            yorum.CreatedUserId = HttpContext.User.Identity.Name;
            string url = Environment.GetEnvironmentVariable("ApiUrl");
            url += "api/yorum/PostYorum/";
            HttpApiHelper helper = new HttpApiHelper(url, "POST");
            string response = helper.GetResponseWithModel(JsonConvert.SerializeObject(yorum));
            //Makale makaleadd = JsonConvert.DeserializeObject<Makale>(response);
            return RedirectToAction("MakaleGet", "Makale", new { id = yorum.MakaleId });
        }

        // PUT: api/Yorum/
        public IActionResult YorumUpdate([FromBody] int id)
        {
            string url = Environment.GetEnvironmentVariable("ApiUrl");
            url += "api/yorum/GetYorum/" + id;
            HttpApiHelper helper = new HttpApiHelper(url, "GET");
            string response = helper.GetResponse();

            Yorum makale = JsonConvert.DeserializeObject<Yorum>(response);
            return View();
        }

        [HttpPost, ActionName("YorumUpdate")]
        public IActionResult YorumUpdaten([FromBody] Yorum yorum)
        {
            yorum.UpdatedUserId = HttpContext.User.Identity.Name;
            string url = Environment.GetEnvironmentVariable("ApiUrl");
            url += "api/yorum/YorumUpdate/";
            HttpApiHelper helper = new HttpApiHelper(url, "PUT");
            string response = helper.GetResponseWithModel(JsonConvert.SerializeObject(yorum));
            return RedirectToAction("MakaleGet", "Makale", new { id = yorum.MakaleId });
        }
        // DELETE: api/ApiWithActions/5
        public IActionResult YorumDelete(int id)
        {
            string url = Environment.GetEnvironmentVariable("ApiUrl");
            url += "api/yorum/YorumDelete/" + id;
            HttpApiHelper helper = new HttpApiHelper(url, "Delete");
            string response = helper.GetResponse();
            return RedirectToAction("MakaleHomePage","Makele");
        }
    }
}
