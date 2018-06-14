using static System.Console;
using static System.Math;

string ToBinaryString(float value) {

    int bitCount = sizeof(float) * 8; // never rely on your knowledge of the size
    char[] result = new char[bitCount]; // better not use string, to avoid ineffective string concatenation repeated in a loop

    int intValue = System.BitConverter.ToInt32(BitConverter.GetBytes(value), 0);

    for (int bit = 0; bit < bitCount; ++bit) {
        int maskedValue = intValue & (1 << bit); // this is how shift and mask is done.
        if (maskedValue > 0)
            maskedValue = 1;
        // at this point, masked value is either int 0 or 1
        result[bitCount - bit - 1] = maskedValue.ToString()[0]; // bits go right-to-left in usual Western Arabic-based notation
    }

    return new string(result); // string from character array
}

WriteLine(3.45);
WriteLine(3.45 * Math.Pow(10, 3));
WriteLine(1.1 * Pow(10, -1));
WriteLine(Convert.ToString(1, 2).PadLeft(8, '0'));

WriteLine(sizeof(float));
WriteLine(3.65d + 0.05d);

WriteLine("float max value = {0}", float.MaxValue.ToString("F10"));
WriteLine("float min value = {0}", float.MinValue.ToString("F10"));
WriteLine("int max value = {0}", int.MaxValue);
WriteLine("int min value = {0}", int.MinValue);


float ff = 123456789012345678901234567890f; //30 digits
Console.WriteLine(ff);  // 1.234568E+29

double dd = 123456789012345678901234567890d; //30 digits
Console.WriteLine(dd); // 1.23456789012346E+29

Console.WriteLine("0.1d {0}", 0.1d.ToString("F10"));

WriteLine(ToBinaryString(1.1f));