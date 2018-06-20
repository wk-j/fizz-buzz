using System.Collections;

class Member {
    public int Id { set; get; }
    public string Name { set; get; }
}

class Comparer : IEqualityComparer<Member> {
    public bool Equals(Member x, Member y) =>
        x.Id == y.Id && x.Name == y.Name;
    public int GetHashCode(Member obj) => obj.Id;
}

var a = new List<Member> {
    new Member { Id = 1, Name = "N1"},
    new Member { Id = 2, Name = "N2"},
};

var b = new List<Member> {
    new Member { Id = 2, Name = "N2" },
    new Member { Id = 2, Name = "N2" },
    new Member { Id = 1, Name = "N1" },
};

List<Member> Clean(List<Member> data) =>
    data.Distinct(new Comparer()).OrderBy(x => x.Id).ToList();

var newA = Clean(a);
var newB = Clean(b);
var isEqual = newA.SequenceEqual(newB, new Comparer());

Console.WriteLine(isEqual);