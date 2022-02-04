using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTeamSystem
{
    public class HockeyPlayer : Person    
    {
        private string _fullName;
        private int _primaryNumber;
        public PlayerPosition Position { get; private set; }
        
        // Define properties with private set for Goals, Assists
        public int Goals { get; private set; }
        public int Assists { get; private set; }
        // Define a computed read-only property for Points (Goals + Assits)
        public int Points
        {
            get { return Goals + Assists; }
        }

        public int PrimaryNumber
        {
            get { return _primaryNumber; }
            private set
            {
                if (value < 1 || value > 99)
                {
                    throw new ArgumentException("HockeyPlayer PrimaryNumber must between 1 and 99.");
                }
                _primaryNumber = value;
            }
        }

#pragma warning disable CS8618
        public HockeyPlayer(string fullName, int primaryNumber, PlayerPosition position, int goals, int assists) : base(fullName)
        {
            PrimaryNumber = primaryNumber;
            Position = position;
            Goals = goals;
            Assists = assists;
        }

        public override string ToString()
        {
            return $"{FullName},{PrimaryNumber},{Position},{Goals},{Assists}";
        }

        // A static (class-level) method can be accessed direvtly without creating an instance object for the class. For example:
        // HockeyPlayer currentPlayer = HockeyPlayer.Parse("...")
        public static HockeyPlayer Parse(string csvLineText)
        {
            const char Delimiter = ',';
            string[] tokens = csvLineText.Split(Delimiter);
/*
            Enum.Parse(typeof(HockeyPlayer), tokens[2]);*/
            // There should be 5 values in the tokens
            if(tokens.Length != 5)
            {
                throw new FormatException($"CSV string not in the expected format. {csvLineText}");
            }
            return new HockeyPlayer(
                fullName: tokens[0],
                primaryNumber: int.Parse(tokens[1]),
                position: (PlayerPosition) Enum.Parse(typeof(PlayerPosition),tokens[2]),
                goals: int.Parse(tokens[3]),
                assists: int.Parse(tokens[4]));
        }

        public static bool TryParse(string csvLineText, out HockeyPlayer player)
        {
            bool result = false;
            player = null;
            try
            {
                player = Parse(csvLineText);
                result = true;
            }
            catch (FormatException ex)
            {
                throw new FormatException(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return result;
        }
    }
}
