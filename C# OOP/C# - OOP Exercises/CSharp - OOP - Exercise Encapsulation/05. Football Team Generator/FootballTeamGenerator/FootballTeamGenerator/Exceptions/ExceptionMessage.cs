using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Exceptions
{
    public static class ExceptionMessage
    {
        private const string DefaultNameException = "A name should not be empty.";
        private const string DefaultStatException = "{0} should be between 0 and 100.";
        private const string DefaultMissingPlayerException = "Player {0} is not in {1} team.";
        private const string DefaultMissingTeamException = "Team {0} does not exist.";

        public static string NameException { get => DefaultNameException; }
        public static string StatException { get => DefaultStatException; }
        public static string MissingPlayerException { get => DefaultMissingPlayerException; }
        public static string MissingTeamException { get=> DefaultMissingTeamException; }
    }
}
