namespace RoslynSandbox
{
    using System;
    using System.IO;
    using NUnit.Framework;

    class Dump
    {
        [Test]
        public void Test()
        {
            foreach (var file in Directory.EnumerateFiles(@"C:\Git\Third party\StyleCopAnalyzers\StyleCop.Analyzers\StyleCop.Analyzers.Benchmarks\Benchmarks"))
            {
                if (file.EndsWith(".generated.cs"))
                {
                    var fileName = file.Replace(".generated.cs", string.Empty);
                    if (!File.Exists(fileName + ".md"))
                    {
                        Console.WriteLine(Path.GetFileName(fileName));
                    }
                }
            }
       }
    }
}
