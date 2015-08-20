using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Awdk.Skus.Framework.Common.EventManager;

namespace Slb.TaiJi.Framework.Common.EventManager
{
    #region Event Definitions
    public delegate void SkusventHandler(object sender, SkusEventArgs args);
    #endregion

    /// <summary>
    /// Event Manager implements the mediator pattern to enable the communication between 
    /// application components
    /// </summary>
    public class SkusEventManager
    {
        #region private variables
        private readonly Dictionary<string, List<SubscriberInfo>> m_EventMap;
        private readonly Dictionary<string, ReaderWriterLock> m_EventLock;
        static private SkusEventManager m_Instance;
        #endregion

        /// <summary>
        /// Constructor for singleton pattern
        /// </summary>
        protected SkusEventManager()
        {
            m_EventMap = new Dictionary<string, List<SubscriberInfo>>();
            m_EventLock = new Dictionary<string, ReaderWriterLock>();
        }

        /// <summary>
        /// Instance property for singleton pattern
        /// </summary>
        static public SkusEventManager Instance
        {
            get { return m_Instance ?? (m_Instance = new SkusEventManager()); }
        }

        /// <summary>
        /// Publish the event with eventName.
        /// Publisher and subscriber of this event are responsible for keeping type consistency of argument e
        /// This is synchronized invocation
        /// </summary>
        /// <param name="publisher"></param>
        /// <param name="eventName"></param>
        /// <param name="e"></param>
        public List<object> PublishEvent(object publisher, string eventName, object data)
        {
            if (!m_EventLock.Keys.Contains(eventName))
                m_EventLock.Add(eventName, new ReaderWriterLock());
            m_EventLock[eventName].AcquireReaderLock(Timeout.Infinite);
            var arguments = new List<object>();
            try
            {
                var subscriberlist = FindSubscriber(eventName);
                foreach (var sub in subscriberlist)
                {
                    var args = new SkusEventArgs { Name = eventName, Data = data };
                    arguments.Add(args);
                    sub.Handler.Invoke(publisher, args);
                }
            }
            finally
            {
                m_EventLock[eventName].ReleaseReaderLock();
            }
            return arguments;
        }

        /// <summary>
        /// Subscribe an event
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="eventName"></param>
        /// <param name="handler"></param>
        public void Subscribe(object subscriber, string eventName, SkusventHandler handler)
        {
            if (subscriber == null)
                throw new ArgumentNullException("subscriber", "Parameter should not be null");
            if (handler == null)
                throw new ArgumentNullException("handler", "Parameter should not be null");

            if (!m_EventLock.Keys.Contains(eventName))
                m_EventLock.Add(eventName, new ReaderWriterLock());
            m_EventLock[eventName].AcquireWriterLock(Timeout.Infinite);

            try
            {
                UnSubscribe(subscriber, eventName);
                CreateSubscriber(eventName);

                var subscriberlist = FindSubscriber(eventName);
                subscriberlist.Add(new SubscriberInfo(subscriber, handler));
            }
            finally
            {
                m_EventLock[eventName].ReleaseWriterLock();
            }
        }

        /// <summary>
        /// Unsubscribe an event
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="eventName"></param>
        public void UnSubscribe(object subscriber, string eventName)
        {
            if (subscriber == null)
                throw new ArgumentNullException("subscriber", "Parameter should not be null");

            if (!m_EventLock.Keys.Contains(eventName))
                m_EventLock.Add(eventName, new ReaderWriterLock());
            m_EventLock[eventName].AcquireWriterLock(Timeout.Infinite);

            try
            {
                var subscriberlist = FindSubscriber(eventName);

                var indexOfSub = subscriberlist.FindIndex(subscriberInfo => subscriberInfo.Subscriber == subscriber);
                if (indexOfSub != -1)
                    subscriberlist.RemoveAt(indexOfSub);
            }
            finally
            {
                m_EventLock[eventName].ReleaseWriterLock();
            }
        }

        #region private functions
        /// <summary>
        /// Find an event. Return all subscriber to this event
        /// </summary>        
        /// <param name="eventName"></param>
        /// <returns></returns>
        private List<SubscriberInfo> FindSubscriber(string eventName)
        {
            return m_EventMap.ContainsKey(eventName)
                ? m_EventMap[eventName]
                : new List<SubscriberInfo>();
        }

        private void CreateSubscriber(string eventName)
        {
            if (!m_EventMap.ContainsKey(eventName))
            {
                m_EventMap.Add(eventName, new List<SubscriberInfo>());
            }
        }

        #endregion
    }
}
