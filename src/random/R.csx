#! "netcoreapp2.1"
#r "nuget:BenchmarkDotNet,0.11.0"

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Test>();

public class MyConfig : ManualConfig {
    public MyConfig() {
        this.Add(Job.Dry.WithLaunchCount(1));
    }
}

[Config(typeof(MyConfig))]
[MemoryDiagnoser]
// [BenchmarkDotNet.Attributes.Jobs.InProcess]
public class Test {

    [Benchmark]
    public void A() {
        String.Format("{0}{1}{2}{3}", "1", "2", "3", "4");
    }

    [Benchmark]
    public void List() {
        var list = Enumerable.Range(1000, 100).ToList();
        var count = list.Count;
        for (int i = count; i > 0; i--) {
            var ran = new Random();
            var index = ran.Next(list.Count);
            list.RemoveAt(index);
        }
    }
}
