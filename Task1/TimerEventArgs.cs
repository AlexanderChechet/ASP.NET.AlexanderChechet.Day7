using System;

namespace Task1
{
    public class TimerEventArgs : EventArgs
    {
        public int Ticks;

        public TimerEventArgs(int ticks)
        {
            Ticks = ticks;
        }
    }
}
