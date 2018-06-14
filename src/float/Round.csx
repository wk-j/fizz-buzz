Console.WriteLine("2.5 = {0}", Math.Round(2.5));
Console.WriteLine("3.5 = {0}", Math.Round(3.5));

Console.WriteLine("2.5 AwayFromZero = {0}", Math.Round(2.5, MidpointRounding.AwayFromZero));
Console.WriteLine("3.5 ToEven = {0}", Math.Round(3.5, MidpointRounding.ToEven));