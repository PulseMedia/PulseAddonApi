using System;
using System.Reflection;

namespace PulseNativeBridge
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class Native : Attribute
    {
        public string Family;

        public Native(string family)
        {
            this.Family = family;
        }
    }

    public class NativeMethod
    {
        public string Name;
        public string Family;
        public MethodInfo Info;
        public NativeMethodParameter[] Params;
        public bool HasParams;
    }

    public class NativeMethodParameter
    {
        public Type Type;
        public bool Optional;
        public object Default;
    }
}
