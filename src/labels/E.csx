#! "netcoreapp2.1"
#r "nuget:wk.FuncCompose,0.1.0"

using System.Linq;
using FuncCompose;

Func<Product, int> Price = (p) => p.Price;
Func<Product, bool> Stocked = (p) => p.Stocked;
Func<int, bool> IsCheap = (i) => i < 100;

class Product {
    public bool Stocked { set; get; }
    public int Price { set; get; }
}

var products = new Product[] {
    new Product { Stocked = true, Price = 80 },
    new Product { Stocked = true, Price = 200 },
    new Product { Stocked = false, Price = 70},
};

var rs = products.Where(Stocked.And(Price.Compose(IsCheap)));
