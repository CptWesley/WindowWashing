using System.Runtime.Versioning;

namespace WindowWashing.Example;

public static class Program
{
    [SupportedOSPlatform("windows")]
    public static void Main()
    {
        ListRecursively(0, 0);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("desktop: " + Win32Windows.GetClassName(Win32Windows.GetDesktopWindow()));
        ListRecursively(Win32Windows.GetDesktopWindow(), 1);
    }

    [SupportedOSPlatform("windows")]
    private static void ListRecursively(nint hWnd, int depth)
    {
        string indent = "";

        for (int i = 0; i < depth; i++)
        {
            indent += "- ";
        }

        foreach (nint child in Win32Windows.EnumChildWindows(hWnd))
        {
            nint parent = Win32Windows.GetParent(child);

            if (parent != hWnd)
            {
                continue;
            }

            string title = Win32Windows.GetWindowText(child);
            string className = Win32Windows.GetClassName(child);

            Console.WriteLine($"{indent}{title} {{class: {className}}}");

            ListRecursively(child, depth + 1);
        }
    }
}