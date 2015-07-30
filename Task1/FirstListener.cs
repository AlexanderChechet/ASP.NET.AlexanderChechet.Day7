using System;

namespace Task1
{
    public class FirstListener
    {
        public void MessageToConsole(object sender, TimerEventArgs args)
        {
            Console.WriteLine("I'm first. Ticks = {0}", args.Ticks);
        }

        public void Register(EventTimer timer)
        {
            timer.Timer += MessageToConsole;
        }

        public void Unregister(EventTimer timer)
        {
            timer.Timer -= MessageToConsole;
        }
    }
}
