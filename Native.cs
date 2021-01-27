using System;
using System.Collections.Generic;
using System.Reflection;

namespace PulseNativeBridge
{
    /// <summary>
    /// Functions marked with this Attribute are handled as Native Method
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class Native : Attribute
    {
        public string Family;

        public Native(string family)
        {
            this.Family = family;
        }
    }

    /// <summary>
    /// Class that holds Information about the Native Method
    /// </summary>
    public class NativeMethod
    {
        public string Name;
        public string Family;
        public MethodInfo Info;
        public NativeMethodParameter[] Params;
        public bool HasParams;
        public List<int> Events;
    }

    /// <summary>
    /// SubClass that holds Information about parameters for the Native Method
    /// </summary>
    public class NativeMethodParameter
    {
        public Type Type;
        public bool Optional;
        public object Default;
        public bool IsEvent;
    }
}
