
var text = "asdfsgfdsgaskjlewr";
var part = 4.0;
var size = (int)Math.Ceiling(text.Length / part);

var array = text.Select((Value, Index) => new { Value, Index })
            .GroupBy(x => x.Index / size)
            .Select(group => new String(group.Select(x => x.Value).ToArray()))
            .ToArray();

var joined = string.Join("", array);

Console.WriteLine(text == joined);