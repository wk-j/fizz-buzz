
var products = new[] {
    new { Stocked = true, Price = 85 },
    new { Stocked = true, Price = 200 },
    new { Stocked = false, Price = 50 }
};

bool Cheap(int i) => i < 100;

Func<T, bool> EveryPred<T>(params Func<T, bool>[] predicate) =>
    (T input) => predicate.Aggregate(true, (acc, func) => acc && func(input));

var cheapInStock = products.Where(EveryPred(k => k.Stocked, k => Cheap(k.Price)));
