class C {
    public int Id { set; get; }
}

struct A {
    public A(int a) => Id = a;
    public int Id { set; get; }
}

var a1 = new A(1);
var a2 = new A(1);

var c1 = new C { Id = 1 };
var c2 = new C { Id = 1 };

var d1 = new { Id = 1 };
var d2 = new { Id = 1 };

Console.WriteLine(c1.GetHashCode() != c2.GetHashCode());    // False
Console.WriteLine(d1.GetHashCode() == d2.GetHashCode());    // True
Console.WriteLine(a1.GetHashCode() == a2.GetHashCode());    // True