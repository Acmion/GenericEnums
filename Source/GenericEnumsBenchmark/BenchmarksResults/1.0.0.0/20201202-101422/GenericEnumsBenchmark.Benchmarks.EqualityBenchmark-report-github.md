``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1198 (1909/November2018Update/19H2)
Intel Core i5-2500K CPU 3.30GHz (Sandy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT


```
|                             Method | NumberOfEnumsInValue | NumberOfEnumsInComparison | NumberOfEnumsInComparisonOfDifferentType |        Mean |     Error |    StdDev |      Median |
|----------------------------------- |--------------------- |-------------------------- |----------------------------------------- |------------:|----------:|----------:|------------:|
|                       EnumEquality |                    3 |                         3 |                                        3 |   0.0021 ns | 0.0040 ns | 0.0038 ns |   0.0000 ns |
|                GenericEnumEquality |                    3 |                         3 |                                        3 |   0.2756 ns | 0.0158 ns | 0.0148 ns |   0.2737 ns |
| GenericEnumOfDifferentTypeEquality |                    3 |                         3 |                                        3 | 260.2816 ns | 2.3753 ns | 2.1057 ns | 260.4707 ns |
