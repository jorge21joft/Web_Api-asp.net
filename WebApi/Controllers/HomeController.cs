using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {

            //link de tutotial:   https://www.youtube.com/watch?v=Z08vmuSh03g

            var httpClient = new HttpClient();

         var Json = await  httpClient.GetStringAsync("http://localhost:59767/api/notas");

            var notaslist = JsonConvert.DeserializeObject<List<notas>>(Json);

            return View(notaslist);
        }
    }
}
