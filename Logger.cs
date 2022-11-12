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
		this.outPut(input);
		this.writeToFile(this.infoFile, input);
    }

	public void Error(string input)
	{
        this.outPut(input);
        this.writeToFile(this.errorFile, input);
    }

    private void outPut(string input)
    {
        this.WriteLine(input);
    }

    private async void writeToFile(string file, string input)
    {
        using StreamWriter outFile = new(file, append: true);
        await outFile.WriteLineAsync(input);
        //await File.WriteAllTextAsync(file, input);
        
    }
}
