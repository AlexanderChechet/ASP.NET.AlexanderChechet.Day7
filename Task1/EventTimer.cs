using System;
using System.Collections.Generic;
using System.Threading;

namespace Task1
{
    public class EventTimer
    {
        #region Private fields
        private readonly int ticks;
        #endregion

        #region Ctor
        public EventTimer(int ticks)
        {
            this.ticks = ticks;
        }
        #endregion

        #region Public delegate and event
        public delegate void TimerEventHandler(object sender, TimerEventArgs args);
        public event TimerEventHandler Timer = delegate { };
        #endregion

        #region Public methods
        public void Start()
        {
            Thread.Sleep(ticks);
            OnTimer(this, new TimerEventArgs(ticks));
        }

        public void Register(TimerEventHandler handler)
        {
            Timer += handler;
        }

        public void Unregister(TimerEventHandler handler)
        {
            Timer -= handler;
        }
        #endregion

        #region Private methods
        protected virtual void OnTimer(object sender, TimerEventArgs args)
        {
            var exceptions = new Queue<Exception>();
            var arrayEventHandler = Timer.GetInvocationList();

            foreach (var itemEventHandler in arrayEventHandler)
            {
                var eventHandler = (TimerEventHandler) itemEventHandler;
                try
                {
                    eventHandler(sender, args);
                }
                catch (Exception e)
                {
                    exceptions.Enqueue(e);
                }
            }

            if (exceptions.Count > 0)
                throw new AggregateException(exceptions);
        }
        #endregion
    }

    
}
