namespace PlayersAndMonsters.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;

    public class ManagerController : IManagerController
    {
        private PlayerRepository players;
        private CardRepository cards;
        private BattleField battleField;

        public ManagerController()
        {
            this.players = new PlayerRepository();
            this.cards = new CardRepository();

            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player;

            if (type == "Beginner")
            {
                player = new Beginner(new CardRepository(), username);
            }
            else
            {
                player = new Advanced(new CardRepository(), username);
            }

            this.players.Add(player);

            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            ICard card;

            if (type == "Trap")
            {
                card = new TrapCard(name);
            }
            else
            {
                card = new MagicCard(name);
            }

            this.cards.Add(card);

            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            ICard card = this.cards.Find(cardName);

            this.players.Find(username).CardRepository.Add(card);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.players.Find(attackUser);
            IPlayer enemy = this.players.Find(enemyUser);

            this.battleField.Fight(attacker, enemy);

            return $"Attack user health {attacker.Health} - Enemy user health {enemy.Health}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in this.players.Players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} - Cards {player.CardRepository.Count}");

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }

                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
