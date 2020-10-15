using BattleCards.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace BattleCards.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            return this.View();
        }

        // GET /home/about
        public HttpResponse About()
        {
            return this.Error("This page doesn't exist.");
        }
    }
}
