using System;

namespace Task1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter timer time");
            int tick;
            try
            {
                tick = int.Parse(System.Console.ReadLine());
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                tick = 1000;
            }
            FirstListener first = new FirstListener();
            SecondListener second = new SecondListener();
            EventTimer timer = new EventTimer(tick);
            timer.Register(Listener);
            first.Register(timer);
            second.Register(timer);
            try
            {
                timer.Start();
            }
            catch (AggregateException e)
            {
                foreach (var innerException in e.InnerExceptions)
                {
                    System.Console.WriteLine(innerException.Message);
                }
            }
            System.Console.ReadLine();
        }

        static void Listener(object sender, TimerEventArgs args)
        {
            System.Console.WriteLine("Timer stopped. Ticks = {0}", args.Ticks);
            throw new Exception("lol");
        }
    }
}
