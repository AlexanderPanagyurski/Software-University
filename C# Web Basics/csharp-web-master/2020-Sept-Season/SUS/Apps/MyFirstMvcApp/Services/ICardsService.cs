using BattleCards.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        void CreateCard(string name, string health, string attack, string description, string imageUrl, string keyword, string universeName);

        List<CardViewModel> AllCards();

        bool IsNameAvailable(string name);
    }
}
