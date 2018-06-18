
var text = "asdfsgfdsgaskjlewr";
var part = 4;
var size = (int)Math.Ceiling(text.Length / (double)part);

var rs = text.Select((Value, Index) => new { Value, Index })
            .GroupBy(x => x.Index / size)
            .Select(group => group.Select(x => x.Value).ToArray());

foreach (var item in rs) {
    Console.WriteLine(string.Join("", item));
}