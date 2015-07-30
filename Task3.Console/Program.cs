namespace Task3.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            for (int i = 0; i < 10; i++)
                queue.Enqueue(i * i);
            foreach (var item in queue)
            {
                System.Console.WriteLine(item);
            }
            System.Console.ReadLine();
        }
    }
}
