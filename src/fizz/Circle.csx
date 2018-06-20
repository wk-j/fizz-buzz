IEnumerable<T> Circle<T>(IEnumerable<T> items) {
    while (true) foreach (var item in items) yield return item;
}

var fizzs = Circle(new[] { "", "", "Fizz" });
var buzzs = Circle(new[] { "", "", "", "", "Buzz" });
var numbers = Enumerable.Range(1, Int32.MaxValue).Select(x => x.ToString());
var words = fizzs
    .Zip(buzzs, (a, b) => a + b)
    .Zip(numbers, (a, b) => new[] { a, b })
    .Select(x => x.Max());

string fizzBuzz(int value) => words.ElementAt(value - 1);

Console.WriteLine(fizzBuzz(15));