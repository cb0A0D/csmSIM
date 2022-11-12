using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

public class Logger
{
	private bool verbose;
	private string infoFile = "info.log";
	private string errorFile = "error.log";

    public Logger()
	{
		verbose = false;
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
		this.outPut(input);
		this.writeToFile(this.infoFile, input);
    }

    public void Info(string[] input)  //handles array of strings input
    {
        foreach (string line in input)
        {
            this.outPut(line);
            this.writeToFile(this.infoFile, line);
        }

    }
    public void Error(string input)
    {
        this.outPut(input);
        this.writeToFile(this.errorFile, input);
    }
    public void Error(string[] input) //handles array of strings input
    {
        foreach (string line in input)
        {
            this.outPut(line);
            this.writeToFile(this.errorFile, line);
        }
    }

    private void outPut(string input)
    {
        if (verbose == true)
        {
            this.WriteLine(input);
        }
    }

    private async void writeToFile(string file, string input)
    {
        using StreamWriter outFile = new(file, append: true);
        await outFile.WriteLineAsync(input);
    }
}
