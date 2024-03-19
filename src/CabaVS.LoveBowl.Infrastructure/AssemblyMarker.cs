using System.Reflection;

namespace CabaVS.LoveBowl.Infrastructure;

public static class AssemblyMarker
{
    public static readonly Assembly Assembly = typeof(AssemblyMarker).Assembly;
}