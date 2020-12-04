``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1198 (1909/November2018Update/19H2)
Intel Core i5-2500K CPU 3.30GHz (Sandy Bridge), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT


```
|                             Method | NumberOfEnumsInValue | NumberOfEnumsInComparison | NumberOfEnumsInComparisonOfDifferentType |        Mean |     Error |    StdDev |      Median |
|----------------------------------- |--------------------- |-------------------------- |----------------------------------------- |------------:|----------:|----------:|------------:|
|                       EnumEquality |                    3 |                         3 |                                        3 |   0.0023 ns | 0.0034 ns | 0.0030 ns |   0.0011 ns |
|                GenericEnumEquality |                    3 |                         3 |                                        3 |   0.0102 ns | 0.0132 ns | 0.0123 ns |   0.0052 ns |
| GenericEnumOfDifferentTypeEquality |                    3 |                         3 |                                        3 | 264.0639 ns | 3.2893 ns | 3.0769 ns | 263.5825 ns |
