using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

public class Logger
{
	private bool verbose;
    private string infoFile = "log_info_default.txt";
    private string errorFile = "log_error_default.txt";
    private string debugFile = "log_debug_default.txt";

    private void updateLogFiles()
    {
        this.infoFile = "log_info_[" + DateTime.Now.ToString("yyyy-MM-dd") + "].txt";
        this.debugFile = "log_debug_[" + DateTime.Now.ToString("yyyy-MM-dd") + "].txt";
        this.errorFile = "log_error_[" + DateTime.Now.ToString("yyyy-MM-dd") + "].txt";
    }
    public Logger()
	{
		verbose = false;
        this.updateLogFiles();
    }
	public Logger(bool verboseFlag)
	{
		verbose = verboseFlag;
        this.updateLogFiles();
    }
    private string DateTimeStamp()
    {
        return DateTime.Now.ToString("yyyy-MM-dd; HH:mm:ss.ffff :::");
    }
    private string TimeStampString(string input)
    {
        return DateTimeStamp() + " " + input;
    }
    private void WriteLine(string[] input)
    {
        foreach (string line in input)
        {
            this.WriteLine(line);
        }
    }

    public string Question(string? question)
    {
        string answer;
        answer = "";
        this.Info($"User Query:[{question}]");
        Console.Write(question);
        answer = Console.ReadLine();
        if (answer == null) { answer = ""; }
        this.Info($"\t\tUser Response:[{answer}]");
        this.Info($"User Query:[{question}; User Response:[{answer}]");
        if (answer == null)
        {
            answer = "";
        }
        return answer;
    }

    public void Info(string[] input)  //handles array of strings input
    {
        foreach (string line in input)
        {
            this.Info(line);
        }

    }
    public void Error(string[] input) //handles array of strings input
    {
        foreach (string line in input)
        {
            this.Error(line);
        }
    }
    private void WriteLine(string input)
    {
        Console.WriteLine(input);
    }

    public void Print(string input)
    {
        this.WriteLine(input);
        this.Info(input);
    }
    public void Info(string input)
	{
        input = TimeStampString(input);
        this.outPut(input);
		this.WriteToFile(this.infoFile, input);
    }

    public void Error(string input)
    {
        input = TimeStampString(input);
        this.outPut(input);
        this.WriteToFile(this.errorFile, input);
    }
    public void Debug(string input)
    {
        input = TimeStampString(input);
        this.outPut(input);
        this.WriteToFile(this.debugFile, input);
    }
    private void outPut(string input)
    {
        if (verbose == true)
        {
            this.WriteLine(input);
        }
    }

    private async void WriteToFile(string file, string input)
    {
        this.updateLogFiles();

        using StreamWriter outFile = new(file, append: true);
        await outFile.WriteLineAsync(input);
    }
}
