using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PulseNativeBridge
{
    public static class Bridge
    {

        public static Action<Promise, object[], string[]> Return;

        public static Action<string, bool, object[]> TriggerEvent;

        public static List<NativeMethod> GetNativeFunctions()
        {
            List<NativeMethod> nativeMethods = new List<NativeMethod>();

            Type[] types = typeof(Native).Assembly.GetTypes();

            Native at;
            MethodInfo[] methods;
            for (int i = 0; i < types.Length; i++)
            {
                methods = types[i].GetMethods(BindingFlags.Public | BindingFlags.Static);
                for (int c = 0; c < methods.Length; c++)
                {
                    at = methods[c].GetCustomAttribute<Native>();
                    if (at != null)
                    {
                        NativeMethod PMethod = new NativeMethod
                        {
                            Name = methods[c].Name,
                            Family = at.Family,
                            Info = methods[c],
                            HasParams = false
                        };
                        ParameterInfo[] args = methods[c].GetParameters();
                        if (args.Length > 0)
                        {
                            if (args[0].ParameterType == typeof(Promise))
                            {
                                args = args.Skip(1).ToArray();
                                if (args.Length > 0)
                                {
                                    List<NativeMethodParameter> parameters = new List<NativeMethodParameter>();
                                    for (int t = 0; t < args.Length; t++)
                                    {

                                        NativeMethodParameter bparam = new NativeMethodParameter()
                                        {
                                            Type = args[t].ParameterType,
                                            Optional = args[t].IsOptional
                                        };
                                        if (bparam.Optional)
                                        {
                                            bparam.Default = args[t].RawDefaultValue;
                                        }
                                        parameters.Add(bparam);
                                    }
                                    PMethod.Params = parameters.ToArray();
                                    PMethod.HasParams = true;
                                }
                            }
                            nativeMethods.Add(PMethod);
                        }
                    }
                }
            }
            return nativeMethods;
        }

    }

}
