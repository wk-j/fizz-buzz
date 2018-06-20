public class C {
    public string F1 { set; get; }
    public override int GetHashCode() {
        return (F1 ?? "").GetHashCode();
    }
    public override string ToString() => F1;
}

var dict = new Dictionary<String, C>() {
    ["A"] = new C() { F1 = "A" },
    ["B"] = new C() { F1 = "B" }
};

Console.WriteLine(dict.ElementAt(0));
dict["A"].F1 = "C";

Console.WriteLine(dict.ElementAt(0));
