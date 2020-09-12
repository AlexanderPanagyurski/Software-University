using FootballTeamGenerator.Exceptions;
using FootballTeamGenerator.Models;
using System;
using System.Linq;

namespace FootballTeamGenerator
{
    public class SratUp
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();



            while (command.ToUpper() != "END")
            {
                try
                {


                    var splitCommand = command.Split(";");

                    if (splitCommand[0] == "Team")
                    {
                        Team team = new Team(splitCommand[1]);
                        TeamFactory.AddTeam(team);
                    }
                    else if (splitCommand[0] == "Add")
                    {
                        int index = TeamFactory.FindTeam(splitCommand[1]);
                        Stats stats = new Stats(int.Parse(splitCommand[3]), int.Parse(splitCommand[4]), int.Parse(splitCommand[5]), int.Parse(splitCommand[6]), int.Parse(splitCommand[7]));
                        Player player = new Player(splitCommand[2], stats);

                        TeamFactory.AddPlayer(player, index);
                    }
                    else if (splitCommand[0] == "Remove")
                    {
                        int index = TeamFactory.FindTeam(splitCommand[1]);
                        TeamFactory.RemovePlayer(splitCommand[2], index);
                    }
                    else if (splitCommand[0] == "Rating")
                    {
                        Team team = TeamFactory.Teams.FirstOrDefault(t => t.Name == splitCommand[1]);

                        if (team == null)
                        {
                            throw new ArgumentException(String.Format(ExceptionMessage.MissingTeamException, splitCommand[1]));
                        }
                        Console.WriteLine($"{team.Name} - {team.Rating}");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                command = Console.ReadLine();
            }
        }
    }
}
