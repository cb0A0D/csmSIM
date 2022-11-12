namespace csmSIM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            bool mainLoop = true;
            long loopCount = 0;
            long loopCountMax = 50;
            while (mainLoop == true) // Feature #1 : Main Loop
            {
                if (loopCount >= loopCountMax) // Main Loop break #1
                {
                    mainLoop = false;
                } else
                {
                    loopCount = loopCount + 1;
                    // TODO : Add API
                }
            }
        } // End Main
    }
}