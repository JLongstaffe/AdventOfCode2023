
using System.Text.RegularExpressions;

namespace Day4.Core;

public class Part2
{
    public int SumCards(string input)
    {
        var lines = input.Split('\n').ToList();

        CardCopies = Enumerable.Range(1, lines.Count)
                               .ToDictionary(i => i, _ => 1);

        lines.ForEach(ProcessCard);

        return CardCopies.Values.Sum();
    }

    private void ProcessCard(string line)
    {
        var match = Regex.Match(line, @"(\d+):(.*)\|(.*)");

        var cardNumber = int.Parse(match.Groups[1].Value);

        var winning = Regex.Matches(match.Groups[2].Value, @"\d+")
                           .Select(m => int.Parse(m.Value));

        var cards = Regex.Matches(match.Groups[3].Value, @"\d+")
                         .Select(m => int.Parse(m.Value));

        var intersect = cards.Intersect(winning).Count();

        Enumerable.Range(cardNumber + 1, intersect).ToList()
                  .ForEach(i => CardCopies[i] += CardCopies[cardNumber]);
    }

    private static IDictionary<int, int> CardCopies = new Dictionary<int, int>();
}
