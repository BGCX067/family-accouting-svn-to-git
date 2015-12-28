using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace Wang.Velika.Utility.GeneralLibrary
{
    public static class ReflectionHelper
    {
        public static Type RetrieveType(string typeName, string assemblyName, string assemblyFile)
        {
            Type ret = null;

            Assembly asm = null;
            if (!String.IsNullOrEmpty(assemblyFile))
            {
                asm = Assembly.LoadFrom(assemblyFile);
            }
            else if (!String.IsNullOrEmpty(assemblyName))
            {
                asm = Assembly.Load(assemblyName);
            }

            if (asm == null)
            {
                ret = Type.GetType(typeName, true);
            }
            else
            {
                ret = asm.GetType(typeName, true);
            }

            return ret;
        }

        public static Stream LoadResourceOfAssembly(Assembly asm, string pathInAssembly)
        {
            return asm.GetManifestResourceStream(pathInAssembly);
        }

        /// <summary>
        /// Copies public properties from <paramref name="source"/> to <paramref name="target"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void CopyByProperties<T>(T source, T target)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }

            Type t = typeof(T);
            PropertyInfo[] pis = t.GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                if (pi.CanRead && pi.CanWrite)
                {
                    object o = pi.GetValue(source, null);
                    pi.SetValue(target, o, null);
                }
            }
        }
    }
}
