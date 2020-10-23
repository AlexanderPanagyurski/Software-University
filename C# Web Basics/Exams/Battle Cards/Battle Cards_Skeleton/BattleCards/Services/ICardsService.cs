using BattleCards.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        void Create(string name, string image, string keyword, string universe, int attack, int health, string description);

        IEnumerable<CardViewModel> AllCards();

        void AddToCollection(int cardId, string userId);

        IEnumerable<CardViewModel> UserAllCards(string userId);

        void RemoveFromCollection(int cardId, string userId);
    }
}
