namespace RoslynSandbox.Dump
{
    using System;
    using System.Reflection;
    using NUnit.Framework;

    internal class TestCases
    {
        static TestCases()
        {
        }

        [Test]
        public void Method()
        {
            var anon = new { Foo = 1 };
            Console.WriteLine(anon.GetType().GetProperty("Foo"));
        }

        [Test]
        public void Methods()
        {
            foreach (var mi in typeof(Console).GetMethods(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly))
            {
                Console.WriteLine(mi);
            }
        }
    }
}
