using System.Reflection;

namespace CabaVS.LoveBowl.Domain;

public static class AssemblyMarker
{
    public static readonly Assembly Assembly = typeof(AssemblyMarker).Assembly;
}