using static System.Console;

List<int> Play(List<int> players, int final, int skip, int startIndex) {
    if (players.Count == final) {
        return players;
    } else {
        var removeIndex = (startIndex + skip) % players.Count;
        var nextPlayers = players.Where((_, i) => i != removeIndex).ToList();
        return Play(nextPlayers, final, skip, removeIndex);
    }
}
var players = Enumerable.Range(1, 100).ToList();
var lastPlayer = Play(players, 5, 1, 0);
WriteLine(string.Join(" ", lastPlayer));  // 9 41 57 73 89