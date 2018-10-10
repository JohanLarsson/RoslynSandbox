namespace RoslynSandbox
{
    using System;

    public class C<T>
        where T : unmanaged
    {
    }
}

namespace RoslynSandbox.Dump
{
    using System;
    using NUnit.Framework;

    internal class TestCases
    {
        [Test]
        public void Method()
        {
            typeof(C<>).MakeGenericType(typeof(Console)).Dump();
        }
    }

    internal static class _
    {
        internal static void Dump(this object o)
        {
            Console.WriteLine(o?.ToString() ?? "null");
        }
    }
}
