using FootballTeamGenerator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public static class TeamFactory
    {
        private static List<Team> teams = new List<Team>();

        public static IReadOnlyCollection<Team> Teams { get => teams.AsReadOnly(); }

        public static void AddTeam(Team team)
        {
            teams.Add(team);
        }

        public static int FindTeam(string name)
        {
            Team team = TeamFactory.Teams.FirstOrDefault(t => t.Name == name);

            if (team == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessage.MissingTeamException, name));
            }
            int index = teams.FindIndex(t => t.Name == name);
            return index;
        }

        public static void AddPlayer(Player player,int index)
        {
            teams[index].AddPlayer(player);
        }

        public static void RemovePlayer(string name,int index)
        {
            teams[index].RemovePlayer(name);
        }
    }
}
