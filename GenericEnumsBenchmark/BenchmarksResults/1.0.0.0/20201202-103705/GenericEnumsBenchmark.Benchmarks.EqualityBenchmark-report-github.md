``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1198 (1909/November2018Update/19H2)
Intel Core i5-2500K CPU 3.30GHz (Sandy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT


```
|                                                  Method | NumberOfEnumsInValue | NumberOfEnumsInComparison | NumberOfEnumsInComparisonOfDifferentType |        Mean |     Error |    StdDev |      Median |
|-------------------------------------------------------- |--------------------- |-------------------------- |----------------------------------------- |------------:|----------:|----------:|------------:|
|                                            EnumEquality |                    3 |                         3 |                                        3 |   0.0024 ns | 0.0059 ns | 0.0052 ns |   0.0000 ns |
|                                     GenericEnumEquality |                    3 |                         3 |                                        3 |   0.0070 ns | 0.0054 ns | 0.0051 ns |   0.0070 ns |
|                      GenericEnumOfDifferentTypeEquality |                    3 |                         3 |                                        3 | 252.6589 ns | 2.2651 ns | 2.1187 ns | 252.6318 ns |
| GenericEnumOfDifferentTypeAndDifferentValueTypeEquality |                    3 |                         3 |                                        3 | 252.3193 ns | 2.1870 ns | 2.0457 ns | 252.3160 ns |
