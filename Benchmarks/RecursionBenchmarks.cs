namespace Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Engines;
    using RecursionDemo;

    public class RecursionBenchmarks
    {
        private readonly Consumer _consumer = new Consumer();

        // NOTE: ExecuteCipherLogic returns an IEnumerable.The execution is deferred. 
        // until the moment when you actually request the data. If your benchmark just returns
        // IEnumerable or IQueryable it's not measuring the execution of the query, just the creation.
        // See: https://benchmarkdotnet.org/articles/samples/IntroDeferredExecution.html
        [Benchmark]
        public void ExecuteRecursionWith1122()
        {
            // note the consume and the lack of a return value
            EncodedMessageHelper.ExecuteCipherLogic("1122", "A1B12C11D2").Consume(_consumer);
        }

        // Run 1: Yield, for loops
        //|                   Method |     Mean |     Error |    StdDev |   Median |
        //|------------------------- |---------:|----------:|----------:|---------:|
        //| ExecuteRecursionWith1122 | 9.364 us | 0.1864 us | 0.5408 us | 9.156 us |

        // Run 2: GetChiper strinc/char optimizations
        //|                   Method |     Mean |     Error |    StdDev |
        //|------------------------- |---------:|----------:|----------:|
        //| ExecuteRecursionWith1122 | 9.169 us | 0.1155 us | 0.0964 us |

        // Run 3: LINQ Where for collection indexing
        //|                   Method |     Mean |    Error |   StdDev |
        //|------------------------- |---------:|---------:|---------:|
        //| ExecuteRecursionWith1122 | 12.68 us | 0.144 us | 0.113 us |

        // Run 4: With ImmutableDictionary cast
        //|                   Method |     Mean |    Error |   StdDev |
        //|------------------------- |---------:|---------:|---------:|
        //| ExecuteRecursionWith1122 | 10.33 us | 0.094 us | 0.083 us |

        // Run 5: With Dictionary cast
        //|                   Method |     Mean |     Error |    StdDev |
        //|------------------------- |---------:|----------:|----------:|
        //| ExecuteRecursionWith1122 | 9.686 us | 0.1933 us | 0.3485 us |

        // Run 6: With Dictionary
        //|                   Method |     Mean |     Error |    StdDev |
        //|------------------------- |---------:|----------:|----------:|
        //| ExecuteRecursionWith1122 | 7.938 us | 0.0873 us | 0.0729 us |
    }
}
