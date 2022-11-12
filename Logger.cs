using Microsoft.VisualBasic;
using System;
using System.Diagnostics;

public class Logger
{
	private bool verbose;

	public Logger()
	{
		verbose = true;
    }
	public Logger(bool verboseFlag)
	{
		verbose = verboseFlag;
    }
	private void WriteLine(string input)
	{
		Console.WriteLine(input);
	}
    public void Info(string input)
	{
		this.WriteLine(input);
	}
}
