namespace RoslynSandbox.Dump
{
    using System;
    using System.Reflection;
    using NUnit.Framework;

    public class Foo
    {
        public Foo(params int[] ints)
        {
            var foo = Activator.CreateInstance(typeof(Foo));
        }
    }

    internal class TestCases
    {
        [Test]
        public void Method()
        {
            Activator.CreateInstance<Foo>();
            //Activator.CreateInstance(typeof(Foo), 1);
            //Activator.CreateInstance(typeof(Foo), "abc");
            //Activator.CreateInstance(typeof(Foo), 1.0);
        }

        internal static void Dump(MemberInfo member)
        {
            Console.WriteLine(member?.ToString() ?? "null");
        }
    }
}
