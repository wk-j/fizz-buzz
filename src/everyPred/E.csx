
var products = new[] {
    new { Stocked = true, Price = 85 },
    new { Stocked = true, Price = 200 },
    new { Stocked = false, Price = 50 }
};

bool Cheap(int i) => i < 100;

bool EveryPred<T>(T input, params Func<T, bool>[] preds) =>
    preds.Aggregate(true, (acc, func) => acc && func(input));

var cheapInStock = products.Where(x => EveryPred(x, k => k.Stocked, k => Cheap(k.Price)));
