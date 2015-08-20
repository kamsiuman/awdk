using System;

namespace Awdk.Skus.Framework.Common.EventManager
{
    public class SkusEventArgs : EventArgs
    {
        public string Name = "";
        public object Data = null;
        public bool Cancel = false;
        public object returnData = null;

        public SkusEventArgs()
        {
        }

        public SkusEventArgs(string name, object data)
        {
            this.Name = name;
            this.Data = data;
        }
    }
}