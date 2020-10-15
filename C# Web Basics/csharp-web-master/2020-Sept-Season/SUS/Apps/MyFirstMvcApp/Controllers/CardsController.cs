using BattleCards.Data;
using BattleCards.Services;
using BattleCards.ViewModels;
using BattleCards.ViewModels;
using Microsoft.EntityFrameworkCore;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly CardsService cardsService;

        public CardsController(CardsService cardsService)
        {
            this.cardsService = cardsService;
        }

        // GET /cards/add
        public HttpResponse Add()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd()
        {
            string attack = this.Request.FormData["attack"];
            string health =this.Request.FormData["health"];
            string description = this.Request.FormData["description"];
            string name = this.Request.FormData["name"];
            string imageUrl = this.Request.FormData["image"];
            string keyword = this.Request.FormData["keyword"];
            string universeName = this.Request.FormData["universe"];

            if (name.Length < 3)
            {
                return this.Error("Name should be at least 3 characters long.");
            }
            if (!this.cardsService.IsNameAvailable(name))
            {
                return this.Error("This card already exists.");
            }

            this.cardsService.CreateCard(name,health, attack, description, imageUrl, keyword, universeName);
            return this.Redirect("/Cards/All");
        }

        // /cards/all
        public HttpResponse All()
        {
            var cardsViewModel = this.cardsService.AllCards();
            return this.View(cardsViewModel);
        }

        // /cards/collection
        public HttpResponse Collection()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }
    }
}
