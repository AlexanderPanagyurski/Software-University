using BattleCards.Data;
using BattleCards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<CardViewModel> AllCards()
        {
            var cardsViewModel = db.Cards.Select(x => new CardViewModel
            {
                Name = x.Name.Replace('-', ' '),
                Description = x.Description,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Type = x.Keyword.Replace('-', ' '),
                UniverseLogoUrl = @$"/img/{x.UniverseName}.png",
                UniverseName = x.UniverseName.Replace('-', ' ')
            }).ToList();

            return cardsViewModel;
        }

        public void CreateCard(string name, string health, string attack, string description, string imageUrl, string keyword, string universeName)
        {
            this.db.Cards.Add(new Card
            {
                Attack = int.Parse(attack),
                Health = int.Parse(health),
                Description = description,
                Name = name,
                ImageUrl = imageUrl,
                Keyword = keyword,
                UniverseName = universeName
            });
            this.db.SaveChanges();
        }

        public bool IsNameAvailable(string name)
        {
            return !this.db.Cards.Any(x => x.Name == name);
        }
    }
}
