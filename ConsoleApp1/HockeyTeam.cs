using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTeamSystem
{
    public class HockeyTeam
    {
        // Define a computed (read-only) property for TotalPoints that
        // sum the Points for each HockeyPlayer in the team
        public int TotalPoints
        {
            get 
            {
                int total = 0;
                foreach (var player in HockeyPlayers)
                {
                    total += player.Points;
                }
                return total;
            }
        }

        // Define a fully-implemented property with a backing field for the team name
        private string _teamName;

        public string TeamName
        {
            get { return _teamName; }
            private set
            {
                //validate the new team name is not null, an empty string or white spaces
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("HockeyName TeamName is required");
                }
                // validate the new team name contains 5 or more characters
                if(value.Trim().Length < 5)
                {
                    throw new ArithmeticException("HocketName TeamName must contain 5 or more characters");
                }

                _teamName = value.Trim();
            }
        }

        // Define an auto-implemented property with a private for the team division
        public TeamDivision Division { get; private set; }

        // Define an auto-implemented readonly property for the HockeyPlayers
        public List<HockeyPlayer> HockeyPlayers { get; } = new List<HockeyPlayer>();

        // Define a read-only property for Playercount
        public int PlayerCount
        {
            get{ return HockeyPlayers.Count; }
        }

        // Define a readonly property with a private set for the Coach
        // The Coach Property is known as Aggregation/Composition when the field/property is an object
        public HockeyCoach Coach { get; private set; }

        // Define a greedy construct that has a parameter for the Team name, team division, and coach
        public HockeyTeam(string teamName, TeamDivision division, HockeyCoach coach)
        {
            TeamName = teamName;
            Division = division;
            Coach = coach;
        }

        // Define a method to ass a player to the team
        public void AddPlayer(HockeyPlayer player)
        {

            //validate that the palyer is not null
            if (player == null)
            {
                throw new ArgumentNullException("HockeyTeam add HockeyPlayer is required.");
            }
            // validate that the number of players is less than 23

            // validate that player (by primary number) is not already on the team
            HockeyPlayers.Add(player);
        }

        public override string ToString()
        {
            return $"{TeamName},{Coach},{Division}";
        }
    }
}
