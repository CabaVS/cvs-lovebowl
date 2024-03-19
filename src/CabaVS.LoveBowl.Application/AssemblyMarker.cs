using System.Reflection;

namespace CabaVS.LoveBowl.Application;

public static class AssemblyMarker
{
    public static readonly Assembly Assembly = typeof(AssemblyMarker).Assembly;
}