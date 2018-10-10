namespace RoslynSandbox
{
    using System;

    public class Foo
    {
        public Foo()
        {
        }

        public Foo(int value)
        {
        }

        public static void Bar(string text)
        {
            typeof(Foo).GetConstructor(Type.EmptyTypes).Invoke(text, null);
        }
    }
}