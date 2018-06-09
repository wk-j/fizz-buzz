int loop(List<int> players) {
    var index = 0;
    while (players.Count() > 1) {
        Console.Write(string.Join(",", players));
        Console.WriteLine("       (" + index);
        index = (index + 1) % players.Count;
        players = players.Where((e, i) => i != index).ToList();
    }
    return players.Last();
}

var players = Enumerable.Range(1, 10).ToList();
var last = loop(players);
Console.WriteLine(last);
