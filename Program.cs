using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading;
using static System.Net.WebRequestMethods;

namespace csmSIM
{
    internal class Program

{
        //private List<User> userList = new List<User>();
        // emailRegEx = $"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;]{0,1}\s*)+$";
        static void TestLogging(Logger logger)
        {
            logger.Info("Simulated Information Message Logging!");
            logger.Debug("Simulated Debug Message Logging!");
            logger.Error("Simulated Error Message Logging!");
        }
        //static bool RunProgram(Logger logger)
        //{
        //    bool continueMainLoop = true;
        //    //bool goodAnswer = false;
        //    bool returnValue = true;
        //    while (continueMainLoop == true)
        //    {
        //        Console.WriteLine("Enter New User Information");
        //        User user = new User(logger);
        //        userList.Add(user);
        //        Console.WriteLine($"userList contains ({userList.Count}) records");
        //        returnValue = ExitProgramMenu(logger);
        //    }
        //    return returnValue;

        //}

        static bool ExitProgramMenu(Logger logger)
        {
            Console.WriteLine();
            bool continueMainLoop = true;
            bool goodAnswer = false;
            while (goodAnswer == false)
            {
                string userQuestion = "Exit Program? [Y|N]:";
                logger.Info($"User Query:[{userQuestion}]");
                Console.Write($"{userQuestion}");
                string userInput = Console.ReadLine();
                userInput = userInput.ToUpper();
                if (userInput == null) { userInput = ""; }
                logger.Info($"User Response:[{userInput}]");
                switch (userInput)
                {
                    case "Y":
                        logger.Info($"User Input [{userInput}] is Valid. Exiting Menu. Exiting Program.");
                        goodAnswer = true;
                        continueMainLoop = false;
                        break;
                    case "N":
                        logger.Info($"User Input [{userInput}] is Valid. Exiting Menu. Continue Program");
                        goodAnswer = true;
                        continueMainLoop = true;
                        break;
                    default:
                        logger.Info($"User Input [{userInput}] is InValid. Showing Menu again.");
                        Console.WriteLine($"Input[{userInput}] is Invalid. Try again.");
                        goodAnswer = false;
                        break;

                }
            }
            Console.WriteLine();
            return continueMainLoop;
        }
        static void Main(string[] args)
        {
            //Logger logs to the execution path
            List<User> userList = new List<User>();
            Logger logger = new Logger();
            logger.Info("Starting Program");

            
            bool mainLoop = true;
            while (mainLoop == true) // Feature #1 : Main Loop
            {
                bool continueMainLoop = true;
                Console.WriteLine("Entering New User Information\n");
                // TODO : Add API
                //User user = new User("a@b.c", "01234567890");
                User user = new User();
                user.GetUserInput();
                userList.Add(user);

                logger.Print(":::::\tUSER RECORD SUMMARY\t:::::\n");
                Console.WriteLine($"User Records({userList.Count})\n");


                // Query User: Exit Program?
                mainLoop = ExitProgramMenu(logger);
            }
            var archiveFile = new StreamWriter(@"csmArchive.csv", append: true);
            string lineOut = "";
            for (int i = 0; i < userList.Count; i++)
            {
                lineOut = "";
                int positionDisplay = i + 1;
                logger.Print($"User Record [{positionDisplay}]");
                logger.Print($"\tUser Email:{userList[i].Email}");
                logger.Print($"\tUser Phone#:{userList[i].PhoneNumber}");
                lineOut = $"{userList[i].Email},{userList[i].PhoneNumber}";
                //await outFile.WriteLineAsync(lineOut);
                archiveFile.WriteLine(lineOut);
                archiveFile.Flush();


            }
            logger.Info("Exiting Application");
        } // End Main
    }
}