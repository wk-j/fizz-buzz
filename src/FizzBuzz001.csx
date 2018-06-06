bool NotEmpty(string s) => !String.IsNullOrEmpty(s);
string FizzBuzz(int value) =>
    string.Concat(
        new[] {
            value % 3 == 0 ? "Fizz" : string.Empty,
            value % 5 == 0 ? "Buzz" : string.Empty
        }
        .Where(NotEmpty)
        .DefaultIfEmpty(value.ToString())
    );

string Fz(int value) =>
    (from fizz in new[] { value % 3 == 0 ? "Fizz" : string.Empty }
     from buzz in new[] { value % 5 == 0 ? "Buzz" : string.Empty }
     let result = fizz + buzz
     where result != string.Empty
     select result
    ).FirstOrDefault() ?? value.ToString();

Console.WriteLine(Fz(7));

Console.WriteLine(FizzBuzz(3));
Console.WriteLine(FizzBuzz(5));
Console.WriteLine(FizzBuzz(7));
Console.WriteLine(FizzBuzz(15));
Console.WriteLine(FizzBuzz(100));
