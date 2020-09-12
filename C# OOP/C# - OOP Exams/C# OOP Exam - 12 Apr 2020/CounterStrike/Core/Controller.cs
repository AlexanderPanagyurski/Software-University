using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;
        private ICollection<IPlayer> allPlayers;
        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;
            if (type == "Pistol")
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name, bulletsCount);
            }
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
            this.guns.Add(gun);
            return String.Format(OutputMessages.SuccessfullyAddedGun, gun.Name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IPlayer player = null;
            IGun gun = this.guns.FindByName(gunName);
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }
            if (type == "Terrorist")
            {
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == "CounterTerrorist")
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }
            this.players.Add(player);

            return String.Format(OutputMessages.SuccessfullyAddedPlayer, player.Username);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            if (allPlayers == null)
            {
                allPlayers = this.players.Models.ToList();
            }
            foreach (var player in allPlayers.OrderBy(p => p.GetType().Name).ThenByDescending(p => p.Health).ThenBy(p => p.Username))
            {
                sb.Append($"{player.GetType().Name}: {player.Username}" + Environment.NewLine);
                sb.Append($"--Health: {player.Health}" + Environment.NewLine);
                sb.Append($"--Armor: {player.Armor}" + Environment.NewLine);
                sb.Append($"--Gun: {player.Gun.Name}" + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            allPlayers = players.Models.ToList();
            return this.map.Start(allPlayers);
        }
    }
}
