``` ini

BenchmarkDotNet=v0.10.14, OS=macOS High Sierra 10.13.3 (17D102) [Darwin 17.4.0]
Intel Core i5-7600K CPU 3.80GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.1.300
  [Host] : .NET Core 2.1.0 (CoreCLR 4.6.26515.07, CoreFX 4.6.26515.06), 64bit RyuJIT

Job=InProcess  Toolchain=InProcessToolchain  

```
| Method | Count |        Mean |      Error |     StdDev |   Gen 0 | Allocated |
|------- |------ |------------:|-----------:|-----------:|--------:|----------:|
|  **Game1** |    **10** |  **2,184.7 ns** |  **48.513 ns** |  **74.085 ns** |  **0.9003** |    **2840 B** |
|  Game2 |    10 |    239.6 ns |   1.904 ns |   1.781 ns |  0.0458 |     144 B |
|  Game3 |    10 |    506.5 ns |   2.215 ns |   1.964 ns |  0.1974 |     624 B |
|  **Game1** |   **100** | **98,526.3 ns** | **681.977 ns** | **637.922 ns** | **28.3203** |   **89336 B** |
|  Game2 |   100 |  2,486.9 ns |  20.136 ns |  16.815 ns |  0.1564 |     504 B |
|  Game3 |   100 |  9,821.7 ns | 195.596 ns | 381.495 ns |  7.4005 |   23304 B |
