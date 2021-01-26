using System;
using System.Collections.Generic;
using System.Text;

namespace PulseNativeBridge.modules.IO
{
    public static class Directory
    {

        [Native(Family.Directory)]
        public static void exists(Promise promise, string directoryPath)
        {
            promise.Resolve(new object[] { System.IO.Directory.Exists(directoryPath) });         
        }

    }
}
