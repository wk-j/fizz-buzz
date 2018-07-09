string Add(string a, string b) {
    var max = a.Length > b.Length ? a.Length : b.Length;
    var pa = a.PadLeft(max, '0');
    var pb = b.PadLeft(max, '0');
    var zip = pa.Zip(pb, (aa, bb) => (int.Parse(aa.ToString()), int.Parse(bb.ToString()))).Reverse();
    var (td, rs) = zip.Aggregate((0, ""), (acc, aabb) => {
        var ((tod, ac), (aa, bb)) = (acc, aabb);
        var pad = $"{aa + bb + tod}".PadLeft(2, '0');
        return (int.Parse(pad.ElementAt(0).ToString()), ac + pad.ElementAt(1));
    });
    return string.Join("", (rs + td).Reverse()).TrimStart('0');
}

string Eval(string input) => input.Split("+").Aggregate((a, b) => Add(a, b));

Console.WriteLine(Add("1234", "1234"));
Console.WriteLine(Add("9999", "9999"));

Console.WriteLine(Eval("1234+1234"));
Console.WriteLine(Eval("1234567890+10"));
Console.WriteLine(Eval("99999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999+1"));
