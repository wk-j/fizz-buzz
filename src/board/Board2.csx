int play(List<int> players, int skip, int index) {
    if (players.Count() == 1) {
        return players.First();
    } else {
        var newIndex = (index + skip) % players.Count;
        return play(players.Where((e, i) => i != newIndex).ToList(), skip, newIndex);
    }
}
var players = Enumerable.Range(1, 100).ToList();
var lastPlayer = play(players, 1, 0);
Console.WriteLine(lastPlayer);