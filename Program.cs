namespace csmSIM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool mainLoop = true;
            long loopCount = 0;
            long loopCountMax = 5;
            while (mainLoop = true) // Feature #1 : Main Loop
            {
                if (loopCount >= loopCountMax) // Main Loop break #1
                {
                    mainLoop = false;
                } else
                {
                    loopCount = loopCount + 1;
                    Console.WriteLine(loopCount.ToString());
                    Console.WriteLine("Hello, World!");
                }
            }
        }
    }
}