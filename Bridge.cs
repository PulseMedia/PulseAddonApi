using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PulseNativeBridge
{
    public static class Bridge
    {
        /// <summary>
        /// Return Action to handle the Return value of the Native Method
        /// </summary>
        public static Action<Promise, object[], string[]> Return;

        /// <summary>
        /// Action to trigger Events/Callbacks that are passed to the Native Method
        /// </summary>
        public static Action<string, object[]> TriggerEvent;

        /// <summary>
        /// Called from MainApp to get NativeFunctions
        /// </summary>
        /// <returns></returns>
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
                            HasParams = false,
                            Events = new List<int>()
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
                                        if(bparam.Type == typeof(PromiseEvent))
                                        {
                                            bparam.IsEvent = true;
                                            PMethod.Events.Add(t);
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
