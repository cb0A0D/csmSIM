namespace csmSIM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool mainLoop = true;
            long loopCount = 0;
            long loopCountMax = 5;
            while (mainLoop = true)
            {
                if (loopCount == loopCountMax)
                {
                    mainLoop = false;
                }
                loopCount++;
                Console.WriteLine("Hello, World!");

            }
        }
    }
}