``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1198 (1909/November2018Update/19H2)
Intel Core i5-2500K CPU 3.30GHz (Sandy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT


```
|                             Method | NumberOfEnumsInValue | NumberOfEnumsInComparison | NumberOfEnumsInComparisonOfDifferentType |        Mean |     Error |    StdDev |      Median |
|----------------------------------- |--------------------- |-------------------------- |----------------------------------------- |------------:|----------:|----------:|------------:|
|                       EnumEquality |                    3 |                         3 |                                        3 |   0.0008 ns | 0.0017 ns | 0.0014 ns |   0.0000 ns |
|                GenericEnumEquality |                    3 |                         3 |                                        3 |   0.2994 ns | 0.0089 ns | 0.0083 ns |   0.2983 ns |
| GenericEnumOfDifferentTypeEquality |                    3 |                         3 |                                        3 | 264.8062 ns | 1.9238 ns | 1.7995 ns | 264.6965 ns |
