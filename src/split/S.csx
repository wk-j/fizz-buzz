var text = "12340808060lsjflsjflll";
var part = 4;

var rs =
    text.Select((Value, Index) => new { Value, Index = Index % part })
        .GroupBy(x => x.Index)
        .Select(group => group.Select(x => x.Value));

foreach (var item in rs) {
    Console.WriteLine(string.Join("", item));
}