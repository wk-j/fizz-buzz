#! "netcoreapp2.1"
#r "nuget:BenchmarkDotNet,0.10.14"

using System.Collections.Generic;
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
                Method | Count |        Mean |         Error |        StdDev |      Median |   Gen 0 | Allocated |
    ------------------ |------ |------------:|--------------:|--------------:|------------:|--------:|----------:|
                 Where |    10 |  2,174.9 ns |    42.9008 ns |    94.1684 ns |  2,209.0 ns |  0.9003 |    2840 B |
          ListRemoveAt |    10 |    243.6 ns |     4.8529 ns |     6.4784 ns |    241.9 ns |  0.0458 |     144 B |
              NewArray |    10 |    541.0 ns |     5.7012 ns |     4.7607 ns |    541.9 ns |  0.1974 |     624 B |
            LinkedList |    10 |  1,126.5 ns |     9.9108 ns |     9.2705 ns |  1,123.1 ns |  0.3624 |    1144 B |
        CustomRemoveAt |    10 |    189.4 ns |     1.0838 ns |     1.0138 ns |    189.2 ns |  0.0432 |     136 B |
     CustomRefRemoveAt |    10 |    152.3 ns |     0.6118 ns |     0.5423 ns |    152.3 ns |  0.0432 |     136 B |
                 Where |   100 | 99,741.4 ns | 1,943.3637 ns | 2,908.7352 ns | 99,699.4 ns | 28.3203 |   89336 B |
          ListRemoveAt |   100 |  2,426.2 ns |    37.5829 ns |    35.1551 ns |  2,422.9 ns |  0.1564 |     504 B |
              NewArray |   100 |  9,031.2 ns |   204.8468 ns |   300.2618 ns |  8,924.3 ns |  7.4005 |   23304 B |
            LinkedList |   100 | 21,479.0 ns |   426.5627 ns |   962.8232 ns | 21,245.0 ns |  3.2043 |   10144 B |
        CustomRemoveAt |   100 |  1,553.9 ns |    23.0390 ns |    21.5507 ns |  1,543.2 ns |  0.1564 |     496 B |
     CustomRefRemoveAt |   100 |  1,567.3 ns |    30.7178 ns |    45.0258 ns |  1,570.8 ns |  0.1564 |     496 B |
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
    public int LinkedList() {
        var players = new LinkedList<int>(Enumerable.Range(1, Count).ToArray());
        var index = 0;
        while (players.Count > 1) {
            index = (index + 1) % players.Count;
            var value = players.ElementAt(index);
            players.Remove(value);
        }
        return players.Last();
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

BenchmarkRunner.Run<Test>();