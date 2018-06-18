
using System.Collections;

class Member {
    public int Id { set; get; }
}

var a = new List<Member> {
    new Member { Id = 0},
    new Member { Id = 1},
};

var b = new List<Member> {
    new Member { Id = 0 },
    new Member { Id = 1 },
};

class Comarer : IEqualityComparer<Member> {
    public bool Equals(Member x, Member y) {
        return x.Id == y.Id;
    }

    public int GetHashCode(Member obj) {
        return obj.Id;
    }
}

var rs = a.SequenceEqual(b, new Comarer());
Console.WriteLine(rs);





