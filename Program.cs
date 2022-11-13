using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace csmSIM
{
    internal class Program
    {
        // emailRegEx = $"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;]{0,1}\s*)+$";
        static void TestLogging(Logger logger)
        {
            logger.Info("Hello, World!");
            logger.Error("Simulated Error");
        }
        static bool RunProgram(Logger logger)
        {
            bool goodAnswer = false;
            bool returnValue = true;
            while ( goodAnswer == false)
            {
                string userQuestion = "Exit Program? [Y|N]:";
                logger.Info($"User Query:[{userQuestion}]");
                Console.Write($"{userQuestion}");
                string userInput = Console.ReadLine().ToUpper();
                logger.Info($"User Response:[{userInput}]");
                switch (userInput)
                {
                    case "Y":
                        logger.Info($"User Input [{userInput}] is Valid. Exiting Menu. Exiting Program.");
                        goodAnswer = true;
                        returnValue = false;
                        break;
                    case "N":
                        logger.Info($"User Input [{userInput}] is Valid. Exiting Menu. Continue Program");
                        goodAnswer = true;
                        returnValue = true;
                        break;
                    default:
                        logger.Info($"User Input [{userInput}] is InValid. Showing Menu again.");
                        Console.WriteLine($"Input[{userInput}] is Invalid. Try again.");
                        break;

                }
            }
            return returnValue;

        }
        static void Main(string[] args)
        {
            //Logger logs to the execution path
            User user = new User(); // Accepts User Input
            Logger logger = new Logger();
            logger.Info("Starting Program");
            
            bool mainLoop = true;
            while (mainLoop == true) // Feature #1 : Main Loop
            {
                // TODO : Add API
                mainLoop = RunProgram(logger);
                if (mainLoop == false)
                {
                    logger.Info("Exiting Application");
                }
            }
        } // End Main
    }
}