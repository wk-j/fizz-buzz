string Add(string a, string b) {
    var max = a.Length > b.Length ? a.Length : b.Length;
    var na = a.PadLeft(max, '0');
    var nb = b.PadLeft(max, '0');
    var zip = na.Zip(nb, (aa, bb) => (aa.ToString(), bb.ToString())).Reverse();
    var (td, rs) = zip.Aggregate(("0", ""), (acc, aabb) => {
        var ((tod, ac), (aa, bb)) = (acc, aabb);
        var result = int.Parse(aa) + int.Parse(bb) + int.Parse(tod);
        var pad = $"{result}".PadLeft(2, '0');
        Console.WriteLine($"{aa} + {bb} + {tod} = {result} {pad}");
        return ($"{pad.ElementAt(0)}", ac + pad.ElementAt(1));
    });
    return string.Join("", (rs + td).Reverse()).TrimStart('0');
}

Console.WriteLine(Add("1234", "1234"));
Console.WriteLine(Add("9999", "9999"));
