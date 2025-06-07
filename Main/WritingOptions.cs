class WritingOptions
{
    // Clear and writes to the file
    public void ClearAndWriteToFile(string directory, string userMessage, string textFileName)
    {
        try
        {
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\" + directory + @"\" + textFileName + ".txt", userMessage);
        }
        catch (Exception errorName)
        {
            System.Console.WriteLine($"Error. Error was: {errorName}");
        }
    }

    public void AppendToTheEndOfTheFile(string directory, string userMessage, string textFileName)
    {
        string originalText;
        string newText;

        try
        {
            originalText = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\" + directory + @"\" + textFileName + ".txt");

            if (originalText == null)
            {
                newText = userMessage;
                System.Console.WriteLine("\nThe file that was written to was empty or did not exist.");
            }
            else
            {
                newText = $"{originalText} {userMessage}";
            }


            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\" + directory + @"\" + textFileName + ".txt", newText);
        }
        catch (Exception errorName)
        {
            System.Console.WriteLine($"Error. Error was: {errorName}");
        }
    }

    public void AppendToBeginningOfFile(string directory, string userMessage, string textFileName)
    {
        string originalText;
        string newText;

        try
        {
            originalText = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\" + directory + @"\" + textFileName + ".txt");

            if (originalText == null)
            {
                newText = userMessage;
                System.Console.WriteLine("\nThe file that was written to was empty or did not exist.");
            }
            else
            {
                newText = originalText.Insert(0, " "); // Whitespace
                newText = newText.Insert(0, userMessage); // Adds the message

                File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\" + directory + @"\" + textFileName + ".txt", newText);

            }
        }
        catch (Exception errorName)
        {
            System.Console.WriteLine($"Error. Error was: {errorName}");
        }
    }


    public void ClearFile(string directory, string textFileName)
    {
        try
        {
            File.WriteAllText(@"C:\Users\" + Environment.UserName + @"\" + directory + @"\" + textFileName + ".txt", " ");
        }
        catch (Exception errorName)
        {
            System.Console.WriteLine($"Error. Error was: {errorName}");
        }
    }
}