
IEnumerable<int> loop(IEnumerable<int> players) {
    while (players.Count() != 1) {
        Console.WriteLine(string.Join(" ", players));
        players = players.Where((e, i) => (players.Count() + i + 1) % 2 == 1).ToList();
        foreach (var item in players) {
            yield return item;
        }
    }
}

var players = Enumerable.Range(1, 10);
var rs = loop(players).Last();
Console.WriteLine(rs);
