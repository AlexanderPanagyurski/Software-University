using BattleCards.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardsService cardsService;

        public CardsController(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }

        public HttpResponse All()
        {
            var cardsViewModel = this.cardsService.AllCards();
            return this.View(cardsViewModel);
        }

        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(string name, string image, string keyword, string universe, int attack, int health, string description)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 5 || name.Length > 30)
            {
                return this.Error("Invalid username. Username should be between 5 and 30 characters.");
            }
            if (string.IsNullOrEmpty(image))
            {
                return this.Error("Card's image is required.");
            }
            if (string.IsNullOrEmpty(keyword))
            {
                return this.Error("Keyword is required.");
            }
            if (attack < 0)
            {
                return this.Error("Attack cannot be negative.");
            }
            if (health < 0)
            {
                return this.Error("Health cannot be negative.");
            }
            if (string.IsNullOrEmpty(description) || description.Length > 200)
            {
                return this.Error("Description is required. Description should be below 200 characters.");
            }
            this.cardsService.Create(name, image, keyword, universe, attack, health, description);
            return this.Redirect("/Cards/All");
        }

        public HttpResponse AddToCollection(int cardId)
        {
            var userId = this.GetUserId();
            cardsService.AddToCollection(cardId, userId);
            return this.Redirect("/Cards/Collection");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            var userId = this.GetUserId();
            cardsService.RemoveFromCollection(cardId, userId);
            return this.Redirect("/Cards/All");
        }

        public HttpResponse Collection()
        {
            var userId = this.GetUserId();
            var viewModel = cardsService.UserAllCards(userId);
            return this.View(viewModel);
        }
    }
}
