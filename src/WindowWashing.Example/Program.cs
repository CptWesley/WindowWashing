using System.Runtime.Versioning;

namespace WindowWashing.Example;

public static class Program
{
    [SupportedOSPlatform("windows")]
    public static void Main()
    {
        ListRecursively(new WindowHandle(0), 0);
    }

    [SupportedOSPlatform("windows")]
    private static void ListRecursively(WindowHandle window, int depth)
    {
        string indent = "";

        for (int i = 0; i < depth; i++)
        {
            indent += "- ";
        }

        foreach (WindowHandle child in window.GetChildren(false).Where(x => x.Exists))
        {
            Console.WriteLine($"{indent}{child.Text} {{class: {child.ClassName}}}");
            ListRecursively(child, depth + 1);
        }
    }
}