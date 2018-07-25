using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace PokeInfo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewData["Message"] = "Message";
            return View();
        }

        [HttpGet]
        [Route("pokemon/{pokeid}")]
        public IActionResult QueryPoke(int pokeid)
        {
            var PokeInfo = new Pokemon();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
                {
                    PokeInfo = ApiResponse;
                }
            ).Wait();
            Console.WriteLine("\n\nThe following is Pokemon Information\n\n");
            Console.WriteLine(PokeInfo);
            ViewData["Name"] = PokeInfo.Name;
            ViewData["Types"] = PokeInfo.Types;
            ViewData["Weight"] = PokeInfo.Weight;
            ViewData["Height"] = PokeInfo.Height;
            return  View("Index");
        }

    }
}
