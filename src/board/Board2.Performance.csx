#! "netcoreapp2.1"
#r "nuget:BenchmarkDotNet,0.10.14"

using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;


[MemoryDiagnoser]
[InProcess]
class Test {

    /*
 Method | Count |        Mean |      Error |     StdDev |   Gen 0 | Allocated |
------- |------ |------------:|-----------:|-----------:|--------:|----------:|
  Game1 |    10 |  2,184.7 ns |  48.513 ns |  74.085 ns |  0.9003 |    2840 B |
  Game2 |    10 |    239.6 ns |   1.904 ns |   1.781 ns |  0.0458 |     144 B |
  Game3 |    10 |    506.5 ns |   2.215 ns |   1.964 ns |  0.1974 |     624 B |
  Game1 |   100 | 98,526.3 ns | 681.977 ns | 637.922 ns | 28.3203 |   89336 B |
  Game2 |   100 |  2,486.9 ns |  20.136 ns |  16.815 ns |  0.1564 |     504 B |
  Game3 |   100 |  9,821.7 ns | 195.596 ns | 381.495 ns |  7.4005 |   23304 B |

     */

    [Params(10, 100)]
    public int Count { set; get; }

    [Benchmark]
    public int Game1() {
        var players = Enumerable.Range(1, Count).ToList();
        var index = 0;
        while (players.Count() > 1) {
            index = (index + 1) % players.Count;
            players = players.Where((e, i) => i != index).ToList();
        }
        return players.Last();
    }

    [Benchmark]
    public int Game2() {
        var players = Enumerable.Range(1, Count).ToList();
        var index = 0;
        while (players.Count() > 1) {
            index = (index + 1) % players.Count;
            players.RemoveAt(index);
        }
        return players.Last();
    }

    [Benchmark]
    public int Game3() {
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

}

/*
var t = new Test();
Console.WriteLine(t.Game1());
Console.WriteLine(t.Game2());
Console.WriteLine(t.Game3());
*/

BenchmarkRunner.Run<Test>();