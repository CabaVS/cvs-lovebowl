using System.Reflection;

namespace CabaVS.LoveBowl.Presentation;

public static class AssemblyMarker
{
    public static readonly Assembly Assembly = typeof(AssemblyMarker).Assembly;
}