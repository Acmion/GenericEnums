``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1198 (1909/November2018Update/19H2)
Intel Core i5-2500K CPU 3.30GHz (Sandy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT


```
|        Method |     Mean |    Error |   StdDev |
|-------------- |---------:|---------:|---------:|
|   Constructor |       NA |       NA |       NA |
| Uninitialized | 46.18 ns | 0.156 ns | 0.122 ns |

Benchmarks with issues:
  TestBenchmark.Constructor: DefaultJob
