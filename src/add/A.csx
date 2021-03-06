string Add(string a, string b) {
    var max = a.Length > b.Length ? a.Length : b.Length;
    var pa = a.PadLeft(max, '0').Select(x => Int32.Parse(x.ToString()));
    var pb = b.PadLeft(max, '0').Select(x => Int32.Parse(x.ToString()));
    var zip = pa.Zip(pb, (aa, bb) => (aa, bb)).Reverse();
    var (keep, result) = zip.Aggregate((0, ""), (acc, aabb) => {
        var ((k, ac), (aa, bb)) = (acc, aabb);
        var pad = $"{aa + bb + k}".PadLeft(2, '0');
        return (int.Parse(pad.Substring(0, 1)), ac + pad.ElementAt(1));
    });
    return string.Join("", (result + keep).Reverse()).TrimStart('0');
}

string Eval(string input) => input.Split("+").Aggregate((a, b) => Add(a, b));

Console.WriteLine(Eval("1234567890+10"));
Console.WriteLine(Eval("99999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999+1"));
