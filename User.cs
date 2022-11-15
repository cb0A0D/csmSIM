using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

public class User
{
    Logger logger;
	bool loggerSet = false;
    private string email = "@";
	private string phoneNumber = "#";

    public string Email 
	{
		get { return email; }   
	}
	public string PhoneNumber
	{
		get { return phoneNumber; }
	}

	private bool UserEmail()
	{
		bool returnValue = false;
		string userInput = "";
        while (returnValue == false)
        {
			string question = "Input User Email:";
			userInput = logger.Question(question);
            bool matchResult = this.EmailRegEx(userInput);
            returnValue = matchResult;
        }
		this.email = userInput;
		return returnValue;
    }

	private bool UserPhoneNumber()
	{
        bool returnValue = false;
        string userInput = "";
		int userInputSize = 0;
        while (returnValue == false)
        {
            string question = "Input User Phone:";
            userInput = logger.Question(question).Replace("-","").Replace("(", "").Replace(")", "").Replace("+", "");
			userInputSize = userInput.Length;
            bool matchResult = this.PhoneNumberRegEx(userInput);
            returnValue = matchResult;
        }
		this.phoneNumber = userInput;
        return returnValue;
    }
    private bool EmailRegEx(string input)
    {
        bool returnValue;
        Regex r = new Regex(@"^[a-zA-Z0-9]+(?:\.[a-zA-Z0-9\._]+)*@[a-zA-Z0-9]+(?:\.[a-zA-Z0-9]+)*$");
        returnValue = r.IsMatch(input);
        if (returnValue == false)
        {
            Console.WriteLine($"User Input:{input} is not a valid formatted email address. Try again.");
        }
        return returnValue;
    }
    private bool PhoneNumberRegEx(string input)
    {
        bool returnValue = false;
        int expectedPhoneNumberSize = 11;
        Regex r = new Regex(@"^([0-9]{11,11})$");
        returnValue = r.IsMatch(input);
        if (returnValue == false)
        {
            Console.WriteLine($"User Input:{input}; Expected Length:{expectedPhoneNumberSize}; Input Size:{input.Length}");
        }
        return returnValue;
    }
	private bool UserInput()
	{
		bool returnValue = false;
		bool userEmailSet = false;
		bool userPhoneNumberSet = false;
		bool acceptableUserInput = false;
        while (acceptableUserInput == false)
        {
			while (userEmailSet == false)
			{
                userEmailSet = this.UserEmail();
            }

            while (userPhoneNumberSet == false)
            {
                userPhoneNumberSet = this.UserPhoneNumber();
            }

            if ( ( userEmailSet==true) & ( userPhoneNumberSet==true) )
			{
				acceptableUserInput = true;
			}
			returnValue = acceptableUserInput;
        }
		return returnValue;
	}
	public User(Logger logger)
	{
		this.logger = logger;
		this.loggerSet = true;
    }
	public User()
	{
        if (this.loggerSet == false)
        {
            this.logger = new Logger();
            this.loggerSet = true;
        }
    }

    public void GetUserInput()
    {
        UserMain();
    }

    public User(string emailInput="", string phoneInput = "")
    {
        this.email = emailInput;
        this.phoneNumber = phoneInput;
    }
	private void UserMain()
	{
        bool acceptableUserInput = false;
        do
        {
            acceptableUserInput = UserInput();
        } while (acceptableUserInput == false);
    }


}
