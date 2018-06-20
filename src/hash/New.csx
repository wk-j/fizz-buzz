// https://github.com/dotnet/corefx/blob/103639b6ff5aa6ab6097f70732530e411817f09b/src/Common/src/CoreLib/System/HashCode.cs

var h1 = HashCode.Combine("Hello");
var h2 = HashCode.Combine("Hello");


Console.WriteLine(h1);
Console.WriteLine(h2);

Console.WriteLine(HashCode.Combine(1, "Hello"));