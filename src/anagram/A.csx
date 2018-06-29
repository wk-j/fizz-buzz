using static System.Console;

bool Anagram(string i1, string i2) {
    var g1 = i1.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    return i2.GroupBy(x => x)
        .All(x => g1.TryGetValue(x.Key, out var count) && x.Count() <= count);
}

WriteLine(Anagram("abcde", "bad"));
WriteLine(Anagram("abcde", "bat"));
WriteLine(Anagram("abcdefg", "cabbage"));
WriteLine(Anagram("abcdefgab", "cabbage"));