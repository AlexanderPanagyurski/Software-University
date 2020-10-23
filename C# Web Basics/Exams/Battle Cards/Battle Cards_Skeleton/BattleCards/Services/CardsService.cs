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

        public void AddToCollection(int cardId, string userId)
        {
            var userCard = this.db.UserCards.FirstOrDefault(x => x.CardId == cardId && userId == x.UserId);

            if (userCard == null)
            {
                this.db.Add(new UserCard
                {
                    UserId = userId,
                    CardId = cardId
                });
            }
            this.db.SaveChanges();
        }

        public IEnumerable<CardViewModel> AllCards()
        {
            var cards = this.db.Cards.Select(x => new CardViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Type = x.Keyword,
                UniverseName = x.UniverseName,
                UniverseLogoUrl = @$"/img/{x.UniverseName}.png",
                Attack = x.Attack,
                Health = x.Health,
                Description = x.Description
            })
                .ToArray();

            return cards;
        }

        public IEnumerable<CardViewModel> UserAllCards(string userId)
        {
            var cards = this.db
                .Cards
                .Where(x => x.Users.Any(x => x.UserId == userId))
                .Select(x => new CardViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Type = x.Keyword,
                    UniverseName = x.UniverseName,
                    UniverseLogoUrl = @$"/img/{x.UniverseName}.png",
                    Attack = x.Attack,
                    Health = x.Health,
                    Description = x.Description
                })
                .ToArray();

            return cards;
        }

        public void Create(string name, string image, string keyword, string universe, int attack, int health, string description)
        {
            var card = new Card
            {
                Name = name,
                ImageUrl = image,
                Keyword = keyword,
                UniverseName = universe,
                Attack = attack,
                Health = health,
                Description = description
            };

            this.db.Cards.Add(card);
            this.db.SaveChanges();
        }

        public void RemoveFromCollection(int cardId, string userId)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Id == userId);
            var card = this.db.UserCards.FirstOrDefault(x => x.CardId == cardId && x.UserId==userId);
            
            user.Cards.Remove(card);
            this.db.SaveChanges();
        }
    }
}
