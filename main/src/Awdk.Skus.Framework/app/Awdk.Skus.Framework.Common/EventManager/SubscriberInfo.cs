using Slb.TaiJi.Framework.Common.EventManager;

namespace Awdk.Skus.Framework.Common.EventManager
{
    class SubscriberInfo
    {
        public SubscriberInfo(object subsciber, SkusventHandler handler)
        {
            Subscriber = subsciber;
            Handler = handler;
        }

        public object Subscriber { get; private set; }

        public SkusventHandler Handler { get; private set; }
    }
}