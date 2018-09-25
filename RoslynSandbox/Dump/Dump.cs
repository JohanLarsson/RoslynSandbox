namespace RoslynSandbox.Dump
{
    using System;
    using System.Reflection;

    internal static class Dump
    {
        internal static void Member(MemberInfo member)
        {
            Console.WriteLine(member?.ToString() ?? "null");
        }
    }
}