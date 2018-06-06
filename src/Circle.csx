using static System.Console;

IEnumerable<T> circle<T>(IEnumerable<T> items) {
    while (true) foreach (var item in items) yield return item;
}

var fizzs = circle(new[] { "", "", "Fizz" });
var buzzs = circle(new[] { "", "", "", "", "Buzz" });
var numbers = Enumerable.Range(1, Int32.MaxValue).Select(x => x.ToString());
var words = fizzs
    .Zip(buzzs, (a, b) => a + b)
    .Zip(numbers, (a, b) => new[] { a, b })
    .Select(x => x.Max());

string fizzBuzz(int value) => words.ElementAt(value - 1);

WriteLine(fizzBuzz(15));



WriteLine(fizzBuzz(1));
WriteLine(fizzBuzz(9));
WriteLine(fizzBuzz(10));
WriteLine(fizzBuzz(11));
WriteLine(fizzBuzz(15));