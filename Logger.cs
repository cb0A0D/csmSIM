using Microsoft.VisualBasic;
using System;
using System.Diagnostics;

public class Logger
{
	private bool verbose;

	public Logger()
	{
		verbose = true;
        this.WriteLine("Logger");
    }
	public Logger(bool verboseFlag)
	{
		verbose = verboseFlag;
        this.WriteLine("Logger");
    }
	private void WriteLine(string input)
	{
		
		Console.WriteLine(input);
	}
}
