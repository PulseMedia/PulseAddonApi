using System;

namespace PulseNativeBridge
{
    public class Class1
    {
        [Native(Family.Test)]
        public static void testMethod(Promise promise)
        {
            System.Diagnostics.Debug.WriteLine("Test Native Function");
        }

    }
}
