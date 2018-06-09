#! "netcoreapp2.1"
#r "nuget:BenchmarkDotNet,0.10.14"

using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;

class LL {
    int[] array;
    int size = 0;
    public LL(int[] array) {
        this.array = array;
        this.size = array.Length;
    }
    public void RemoveAt(int index) {
        Array.Copy(array, index + 1, array, index, size - index - 1);
        size--;
    }
    public int Size() => size;
    public int Last() => array.ElementAt(size - 1);
}

class LL2 {
    int[] array;
    int size = 0;
    public LL2(int[] array) {
        this.array = array;
        this.size = array.Length;
    }
    public void RemoveAt(ref int index) {
        Array.Copy(array, index + 1, array, index, size - index - 1);
        size--;
    }
    public ref int Size() => ref size;
    public ref int Last() => ref array[size - 1];
}


[MemoryDiagnoser]
[InProcess]
class Test {

    /*
 Method | Count |        Mean |        Error |       StdDev |   Gen 0 | Allocated |
------- |------ |------------:|-------------:|-------------:|--------:|----------:|
  Game1 |    10 |  1,979.8 ns |    14.252 ns |    12.634 ns |  0.9003 |    2840 B |
  Game2 |    10 |    239.0 ns |     4.638 ns |     6.502 ns |  0.0458 |     144 B |
  Game3 |    10 |    500.2 ns |    10.758 ns |    10.063 ns |  0.1974 |     624 B |
  Game4 |    10 |    177.6 ns |     3.444 ns |     3.383 ns |  0.0432 |     136 B |
  Game1 |   100 | 95,774.9 ns | 2,171.834 ns | 2,501.087 ns | 28.3203 |   89336 B |
  Game2 |   100 |  2,352.8 ns |    10.296 ns |     9.631 ns |  0.1564 |     504 B |
  Game3 |   100 |  9,388.6 ns |   195.789 ns |   508.882 ns |  7.4005 |   23304 B |
  Game4 |   100 |  1,511.7 ns |    11.236 ns |     9.960 ns |  0.1564 |     496 B |

     */

    [Params(10, 100)]
    public int Count { set; get; }

    [Benchmark]
    public int Where() {
        var players = Enumerable.Range(1, Count).ToList();
        var index = 0;
        while (players.Count() > 1) {
            index = (index + 1) % players.Count;
            players = players.Where((e, i) => i != index).ToList();
        }
        return players.Last();
    }

    [Benchmark]
    public int ListRemoveAt() {
        var players = Enumerable.Range(1, Count).ToList();
        var index = 0;
        while (players.Count() > 1) {
            index = (index + 1) % players.Count;
            players.RemoveAt(index);
        }
        return players.Last();
    }


    [Benchmark]
    public int NewArray() {
        var players = Enumerable.Range(1, Count).ToList().ToArray();
        var index = 0;
        while (players.Count() > 1) {
            index = (index + 1) % players.Length;
            players = RemoveIndices(players, index);
        }
        return players.Last();
    }

    private static int[] RemoveIndices(int[] IndicesArray, int RemoveAt) {
        var newIndicesArray = new int[IndicesArray.Length - 1];
        var i = 0;
        var j = 0;
        while (i < IndicesArray.Length) {
            if (i != RemoveAt) {
                newIndicesArray[j] = IndicesArray[i];
                j++;
            }
            i++;
        }
        return newIndicesArray;
    }

    [Benchmark]
    public int CustomRemoveAt() {
        var players = new LL(Enumerable.Range(1, Count).ToArray());
        var index = 0;
        while (players.Size() > 1) {
            index = (index + 1) % players.Size();
            players.RemoveAt(index);
        }
        return players.Last();
    }

    [Benchmark]
    public int CustomRefRemoveAt() {
        var array = Enumerable.Range(1, Count).ToArray();
        var players = new LL2(array);
        var index = 0;
        while (players.Size() > 1) {
            index = (index + 1) % players.Size();
            players.RemoveAt(ref index);
        }
        return players.Last();
    }
}



var t = new Test();
t.Count = 100;
Console.WriteLine(t.CustomRefRemoveAt());

BenchmarkRunner.Run<Test>();