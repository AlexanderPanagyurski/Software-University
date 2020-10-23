using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.ViewModels
{
    public class UserAllCardsViewModel
    {
        public IEnumerable<CardViewModel> Cards { get; set; }
    }
}
