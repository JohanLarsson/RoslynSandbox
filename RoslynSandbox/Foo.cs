namespace RoslynSandbox
{
    using System;

    public class Foo
    {
        public Foo(params int[] ints)
        {
            var foo = Activator.CreateInstance(typeof(Foo));
        }
    }
}