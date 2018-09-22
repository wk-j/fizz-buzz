bool Hangman(string w, char[] c) => w.All(c.Contains);

var rs = Hangman("bigbears", "aeioucdprkljh".ToCharArray());
Console.WriteLine(rs);