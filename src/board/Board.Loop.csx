using static System.Console;

List<int> Play(List<int> players, int final, int skip, int startIndex) {
    while (players.Count > final) {
        startIndex = (startIndex + skip) % players.Count;
        players.RemoveAt(startIndex);
    }
    return players;
}
var players = Enumerable.Range(1, 100).ToList();
var lastPlayer = Play(players, 5, 1, 0);
WriteLine(string.Join(" ", lastPlayer));