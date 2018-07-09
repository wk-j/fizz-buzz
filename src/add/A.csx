string Add(string a, string b) {
    var max = a.Length > b.Length ? a.Length : b.Length;
    var na = a.PadLeft(max, '0').Reverse();
    var nb = b.PadLeft(max, '0').Reverse();
    var zip = na.Zip(nb, (aa, bb) => new { A = aa.ToString(), B = bb.ToString() });
    var rs = zip.Aggregate(("0", ""), (acc, dy) => {
        var result = int.Parse(dy.A) + int.Parse(dy.B) + int.Parse(acc.Item1);
        var pad = $"{result}".PadLeft(2, '0');
        return ($"{pad.ElementAt(0)}", acc.Item2 + pad.ElementAt(1));
    });
    return string.Join("", (rs.Item2 + rs.Item1).Reverse()).TrimStart('0');
}


Console.WriteLine(Add("1234", "1234"));
Console.WriteLine(Add("9999", "9999"));

