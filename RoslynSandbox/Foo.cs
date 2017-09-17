namespace RoslynSandbox
{
    using System.IO;

    public class Foo
    {
        private readonly Stream stream = File.OpenRead(string.Empty);
    }
}
