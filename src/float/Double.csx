
var text = "0100000001000111001101101101001001001000010101110011000100100011";

var sign = string.Join("", text.Take(1));
var exponent = string.Join("", text.Skip(1).Take(11));
var mantissa = string.Join("", text.Skip(12).Take(52));

var man = "0111001101101101001001001000010101110011000100100011";

var signValue = Convert.ToInt32(sign, 2);
var exponentValue = Convert.ToInt32(exponent, 2);
var mantissaValue = Convert.ToInt64(mantissa, 2);

var realMantissa = "1." + mantissaValue;
var realMantissaValue = Convert.ToDouble(realMantissa);

Console.WriteLine("sign = {0}", signValue);
Console.WriteLine("exponent = {0}", exponentValue);
Console.WriteLine("mantissa = {0}", mantissaValue);
Console.WriteLine("real mantissa = {0}", realMantissaValue);

var value = Math.Pow(-1, signValue) * realMantissaValue * Math.Pow(2, 5);
Console.WriteLine("value = {0}", value); // ???????

Console.WriteLine(Math.Pow(-1, 0));

