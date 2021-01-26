namespace PulseNativeBridge
{
    /// <summary>
    /// Class that hold Informations to Resolve the Return value(s)
    /// </summary>
    public class Promise
    {
        public string id;

        public bool isCallback;

        public bool noReturn;

        public Promise(string id, bool isCallback, bool noReturn = false)
        {
            this.id = id;
            this.isCallback = isCallback;
            this.noReturn = noReturn;
        }

        public void Resolve(object[] toReturn, string[] eventsToCancel = null)
        {
            if (noReturn) { return; }
            if (eventsToCancel == null)
            {
                eventsToCancel = new string[0];
            }
            Bridge.Return(this, toReturn, eventsToCancel);
        }
    }
}
