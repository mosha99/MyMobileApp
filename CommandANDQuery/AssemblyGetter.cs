using System.Reflection;

namespace CommandANDQuery;

public class AssemblyGetter
{
    public static Assembly assembly => typeof(AssemblyGetter).Assembly;
}