using System;
using System.Collections.Generic;
using System.Reflection;

namespace SampleWeb.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Assembly> GetAssemblies(this Assembly entryAssembly)
        {
            var list = new List<string>();
            var stack = new Stack<Assembly>();

            stack.Push(entryAssembly);

            do
            {
                var assembly = stack.Pop();
                yield return assembly;

                foreach (var reference in assembly.GetReferencedAssemblies())
                {
                    if (!list.Contains(reference.FullName))
                    {
                        Assembly referenceAssembly = null;

                        try
                        {
                            referenceAssembly = Assembly.Load(reference);
                        }
                        catch (Exception)
                        {

                        }

                        if (referenceAssembly != null)
                        {
                            stack.Push(referenceAssembly);
                            list.Add(reference.FullName);
                        }
                    }
                }
            } while (stack.Count > 0);
        }
    }
}