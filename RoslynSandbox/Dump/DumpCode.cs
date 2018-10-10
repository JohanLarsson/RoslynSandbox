namespace RoslynSandbox.Dump
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    internal class DumpMember
    {
        [Test]
        public void FindMember()
        {
            foreach (var type in typeof(Console).Assembly.GetTypes().Where(x => x.IsClass && x.IsPublic && !x.IsSealed))
            {
                foreach (var member in type.GetProperties())
                {
                    if (member.GetMethod?.IsFamily == true)
                    {
                        Dump(member);
                    }
                }
            }
        }

        [Test]
        public void Overloaded()
        {
            foreach (var type in typeof(object).Assembly.GetTypes().OrderBy(x => x.Name))
            {
                foreach (var overloaded in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                                               .GroupBy(x => (x.Name, x.GetParameters().Length)).Where(x => x.Count() > 1))
                {
                    foreach (var method in overloaded)
                    {
                        Console.WriteLine($"typeof({type.FullName}).GetMethod(nameof({type.FullName}.{method.Name}), new[] {{ {string.Join(", ", method.GetParameters().Select(x => $"typeof({x.ParameterType.FullName})"))} }})");
                        var types = method.GetParameters().Select(x => x.ParameterType);
                    }
                }
            }
        }

        internal static void Dump(MemberInfo member)
        {
            Console.WriteLine(member?.ToString() ?? "null");
        }
    }
}