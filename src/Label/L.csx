#! "netcoreapp2.1"
#r "nuget:wk.FuncCompose,0.1.0"

using FuncCompose;

var products = new[] {
    new { Stocked = true, Price = 80 },
    new { Stocked = true, Price = 200 }
};

bool IsCheap(int i) => i < 100;
products.Where(x => x.Stocked && IsCheap(x.Price));