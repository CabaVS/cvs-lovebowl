using System.Reflection;

namespace CabaVS.LoveBowl.Persistence;

public static class AssemblyMarker
{
    public static readonly Assembly Assembly = typeof(AssemblyMarker).Assembly;
}