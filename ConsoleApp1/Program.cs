// See https://aka.ms/new-console-template for more information
using HockeyTeamSystem;
using static System.Console;
using System.Text.Json;


//Define a constant for the location of players CSV data file
const string HockeyPlayerCsvFile = "../../../HockeyPlayers.csv";
const string HockeyTeamJsonFile = "../../../HockeyTeam.json";

WriteLine("Creating CSV file for hockey players.");
CreateHockeyPlayers();
HockeyTeam currentTeam = ReadHockeyPlayersCSVFile(HockeyPlayerCsvFile);
DisplayHockeyTeam(currentTeam);
WriteHockeyTeamToJsonFile(currentTeam, HockeyTeamJsonFile);
currentTeam = ReadHockeyTeamFromJsonFile(HockeyTeamJsonFile);
DisplayHockeyTeam(currentTeam);

static void CreateHockeyPlayers()
{
    try
    {
        // Create a new HockeyCoach instance for the team
        HockeyCoach coach = new HockeyCoach("Dave Tippet", "May 28, 2019");
        // Create players for the team
        HockeyPlayer player1 = new HockeyPlayer("leion Draisaitl", 69, PlayerPosition.Center, 29, 30);
        HockeyPlayer player2 = new HockeyPlayer("Connor McDavid", 97, PlayerPosition.Center, 20, 40);
        HockeyPlayer player3 = new HockeyPlayer("Ryan Nugent-Hopkins", 93, PlayerPosition.Center, 3, 24);
        HockeyPlayer player4 = new HockeyPlayer("Jesse Puljujarvi", 80, PlayerPosition.RightWing, 10, 15);

        HockeyTeam team1 = new HockeyTeam("Edmonton Oilers", TeamDivision.Pacific, coach);

        team1.AddPlayer(player1);
        team1.AddPlayer(player2);
        team1.AddPlayer(player3);
        team1.AddPlayer(player4);

        //WriteLine(team1);

        // Create a list of Hockey players to a csv file
        // step 1 : Create a csv line for each hockey player and add it to a list of string values
        List<string> csvLines = new();
        foreach (var currentPlayer in team1.HockeyPlayers)
        {
            csvLines.Add(currentPlayer.ToString());
        }

        // Step 2: Write all the lines in the list of string values to a file
        File.WriteAllLines(HockeyPlayerCsvFile, csvLines);

        // or
        /*using(StreamWriter sw = new StreamWriter(HockeyPlayerCsvFile))
        {
            foreach(var player in team1.HockeyPlayers)
            {
                sw.WriteLine(player);
            }
        }*/

        // Display the location absolute path of csv data file
        WriteLine($"Successfully created csv file at: {Path.GetFullPath(HockeyPlayerCsvFile)}");

        ReadHockeyTeamFromJsonFile(HockeyTeamJsonFile);
    }
    catch (Exception ex)
    {
        WriteLine($"Error writing to CSV file with exception: {ex.Message}");
    }

}

static HockeyTeam ReadHockeyPlayersCSVFile(string csvFilePath)
{
    HockeyCoach coach1 = new("Dave Tippet", "May 28 2019");
    HockeyTeam Team1 = new("Edmonton Oilers", TeamDivision.Pacific, coach1);
    try
    {
        //Read all the line from the file and return an array of string values for each line
        string[] allLinesArray = File.ReadAllLines(csvFilePath);
        foreach (string line in allLinesArray)
        {
            try
            {
                HockeyPlayer player = null;
                bool success = HockeyPlayer.TryParse(line, out player);
                if (success)
                {
                    Team1.AddPlayer(player);
                }
            }
            catch(FormatException ex)
            {
                WriteLine($"Format Exception: {ex.Message}");
            }
            catch(ArgumentException ex)
            {
                WriteLine($"Argument Null Exception: {ex.Message}");
            }
            catch(Exception ex)
            {
                WriteLine($"Error parsing data from line exception: {ex.Message}");
            }
        }

        /*using (StreamReader reader = new StreamReader(csvFilePath))
        {

        }*/
    }
    catch(Exception ex)
    {
        WriteLine(ex.Message);
    }
    return Team1;
}

static void DisplayHockeyTeam(HockeyTeam currentTeam)
{
    if(currentTeam == null)
    {
        WriteLine("Hockey Team is required");
    }
    else
    {
        WriteLine($"Coach: {currentTeam.Coach}");
        if(currentTeam.HockeyPlayers.Count == 0)
        {
            WriteLine($"There are no Players in {currentTeam.TeamName}");
        }
        else
        {
            WriteLine($"Hockey Players for {currentTeam.TeamName}");
            foreach(HockeyPlayer currentPlayer in currentTeam.HockeyPlayers)
            {
                WriteLine($"Hockey Player: {currentPlayer}");
            }
        }

    }

}

static void WriteHockeyTeamToJsonFile(HockeyTeam currentTeam, string jsonFilePath)
{
    try
    {
        // Make Sure that System.Text.Json is used
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        };
        string jsonString = JsonSerializer.Serialize<HockeyTeam>(currentTeam, options);
        File.WriteAllText(jsonFilePath, jsonString);
        WriteLine($"Successfully created JSON file at {Path.GetFullPath(jsonFilePath)}");
    }
    catch(Exception ex)
    {
        WriteLine(ex.Message);
    }
}

static HockeyTeam ReadHockeyTeamFromJsonFile(string jsonFilePath)
{
    HockeyTeam currentTeam = null;
    try
    {
        string jsonString = File.ReadAllText(jsonFilePath);
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        };
        currentTeam = JsonSerializer.Deserialize<HockeyTeam>(jsonString, options);

        /*currentTeam = Newtonsoft.Json.JsonConvert.DeserializeObject<HockeyTeam>(jsonString, new Newtonsoft.Json.JsonSerializerSettings()
        {
            ConstructorHandling = Newtonsoft.Json.ConstructorHandling.AllowNonPublicDefaultConstructor
        });*/

        DisplayHockeyTeam(currentTeam);
    }
    catch (Exception ex)
    {
        WriteLine("Error reading from jsonfile with exception: {ex.Message}");
    }
    return currentTeam;
}
// Read the list of hockey players from the csv file
/*try
{
    string[] csvLineArray = File.ReadAllLines(HockeyPlayerCsvFile);

    foreach (string line in csvLineArray)
    {
        HockeyPlayer currentPlayer = null;
        bool success = HockeyPlayer.TryParse(line, out currentPlayer);
        WriteLine(currentPlayer);
    }
}
catch (Exception ex)
{
    WriteLine(ex);
}
*/






/*Person person1 = new Person("Ian Burac");

// Test with valid FullName,PrimaryNumber, and Position
HockeyPlayer player1 = new("Connor", 97, PlayerPosition.Center);
Console.WriteLine(player1);

try
{
    HockeyPlayer player2 = new("Connor", 0, PlayerPosition.Center);
    Console.WriteLine("test case has failed");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    HockeyPlayer player3 = new("", 7, PlayerPosition.Center);
    Console.WriteLine("test case has failed");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}*/

