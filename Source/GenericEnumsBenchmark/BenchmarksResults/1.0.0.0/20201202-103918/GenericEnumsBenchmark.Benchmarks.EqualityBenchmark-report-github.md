``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1198 (1909/November2018Update/19H2)
Intel Core i5-2500K CPU 3.30GHz (Sandy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT


```
|                                                  Method | NumberOfEnumsInValue | NumberOfEnumsInComparison | NumberOfEnumsInComparisonOfDifferentType |        Mean |     Error |    StdDev |
|-------------------------------------------------------- |--------------------- |-------------------------- |----------------------------------------- |------------:|----------:|----------:|
|                                            EnumEquality |                    3 |                         3 |                                        3 |   0.1944 ns | 0.0102 ns | 0.0096 ns |
|                                     GenericEnumEquality |                    3 |                         3 |                                        3 |   0.0074 ns | 0.0048 ns | 0.0037 ns |
|                      GenericEnumOfDifferentTypeEquality |                    3 |                         3 |                                        3 | 260.0024 ns | 1.4328 ns | 1.3402 ns |
| GenericEnumOfDifferentTypeAndDifferentValueTypeEquality |                    3 |                         3 |                                        3 | 260.0665 ns | 0.8069 ns | 0.6300 ns |
