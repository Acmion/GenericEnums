``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1198 (1909/November2018Update/19H2)
Intel Core i5-2500K CPU 3.30GHz (Sandy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT


```
|                                                  Method | NumberOfEnumsInValue | NumberOfEnumsInComparison | NumberOfEnumsInComparisonOfDifferentType |        Mean |     Error |    StdDev |      Median |
|-------------------------------------------------------- |--------------------- |-------------------------- |----------------------------------------- |------------:|----------:|----------:|------------:|
|                                            EnumEquality |                    3 |                         3 |                                        3 |   0.0072 ns | 0.0084 ns | 0.0079 ns |   0.0062 ns |
|                                     GenericEnumEquality |                    3 |                         3 |                                        3 |   0.0062 ns | 0.0074 ns | 0.0069 ns |   0.0037 ns |
|                      GenericEnumOfDifferentTypeEquality |                    3 |                         3 |                                        3 | 259.6395 ns | 3.3380 ns | 3.1223 ns | 260.5933 ns |
| GenericEnumOfDifferentTypeAndDifferentValueTypeEquality |                    3 |                         3 |                                        3 | 256.9099 ns | 1.3353 ns | 1.2491 ns | 256.9640 ns |
