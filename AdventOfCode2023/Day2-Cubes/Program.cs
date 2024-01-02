using System.Text.RegularExpressions;

var input = File.ReadAllLines("input.txt");
var maxBlue = 14;
var maxRed = 12;
var maxGreen = 13;




var validGames = new List<int>();

var gameIdRegex = new Regex("Game\\s(\\d+)");
var greenRegex = new Regex("(\\d+)\\sgreen");
var blueRegex = new Regex("(\\d+)\\sblue");
var redRegex = new Regex("(\\d+)\\sred");

foreach (var game in input)
{
    var id = gameIdRegex.Matches(game)[1];
    var greens = greenRegex.Matches(game);
    var blues = blueRegex.Matches(game);
    var reds = redRegex.Matches(game);


    var greensMax = greens.Select(x => Int32.Parse(x.Groups[1].Value)).Max();
    var bluesMax = blues.Select(x => Int32.Parse(x.Groups[1].Value)).Max();
    var redsMax = reds.Select(x => Int32.Parse(x.Groups[1].Value)).Max();
    if (redsMax <= maxRed && greensMax <= maxGreen && bluesMax <= maxBlue)
    {
        validGames.Add(Int32.Parse(id.Value));
    }
}

Console.WriteLine(validGames.Sum());