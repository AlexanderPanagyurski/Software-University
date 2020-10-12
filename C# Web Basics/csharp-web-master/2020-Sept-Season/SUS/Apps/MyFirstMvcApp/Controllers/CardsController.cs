﻿using BattleCards.Data;
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
        // GET /cards/add
        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd()
        {
            var dbContext = new ApplicationDbContext();

            if (this.Request.FormData["name"].Length < 3)
            {
                return this.Error("Name should be at least 3 characters long.");
            }

            dbContext.Cards.Add(new Card
            {
                Attack = int.Parse(this.Request.FormData["attack"]),
                Health = int.Parse(this.Request.FormData["health"]),
                Description = this.Request.FormData["description"],
                Name = this.Request.FormData["name"],
                ImageUrl = this.Request.FormData["image"],
                Keyword = this.Request.FormData["keyword"],
                UniverseName = this.Request.FormData["universe"]
            });
            dbContext.SaveChanges();

            return this.Redirect("/Cards/All");
        }

        // /cards/all
        public HttpResponse All()
        {
            var db = new ApplicationDbContext();
            var cardsViewModel = db.Cards.Select(x => new CardViewModel
            {
                Name = x.Name.Replace('-', ' '),
                Description = x.Description,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Type = x.Keyword.Replace('-',' '),
                UniverseLogoUrl=@$"/img/{x.UniverseName}.png",
                UniverseName = x.UniverseName.Replace('-', ' ')
            }).ToList();

            return this.View(new AllCardsViewModel { Cards = cardsViewModel });
        }

        // /cards/collection
        public HttpResponse Collection()
        {
            return this.View();
        }
    }
}
