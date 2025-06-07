using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class ReadingAndWriting
{
    // Variables, Fields, and Properties
    private enum UserOptions
    {
        ClearAndWriteToFile,
        ClearFile,
        AppendToEndOfFile,
        AppendToBeginningOfFile
    }

    public string TextFileName;
    public string FileContents { get; private set; }
    private string[] _filePaths = { "Desktop", "Videos", "Downloads", "Documents" };
    private WritingOptions writingOptions = new WritingOptions();

    public ReadingAndWriting(string filename)
    {
        TextFileName = filename;
    }

    public void ReadFile()
    {
        foreach (string path in _filePaths)
        {
            try
            {
                FileContents = File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\" + path + @"\" + TextFileName + ".txt");
                if (FileContents != null)
                {
                    System.Console.WriteLine("Found file in: " + @"C:\Users\" + Environment.UserName + @"\" + path);
                }
            }
            catch (Exception)
            {
                System.Console.WriteLine("Couldn't find file in: " + @"C:\Users\" + Environment.UserName + @"\" + path);
            }
        }
    }

    public void WriteFile()
    {
        string userMessage;
        string userInput;
        bool leaveLoop = false;
        string warning = "Script doesn't know if the file exists or not in said Directory, or if the file exists at all... May create a new file. Please use the ReadFile() method to find the file first, next time, before writing to it\n";
        do
        {
            System.Console.WriteLine($"Please select the Directory (Supported Directories are: ( {UseableFilePaths.SupportedFilePaths(_filePaths)})");
            userInput = System.Console.ReadLine();


            if (_filePaths.Contains<string>(userInput))
            {
                leaveLoop = true;
            }

        } while (!leaveLoop);

        System.Console.WriteLine(" "); // Adds blankline

        // Calls UserOptions Method, using a switch for logic.
        switch (UserWriteOptions())
        {
            case UserOptions.ClearAndWriteToFile:
                if (FileContents == null)
                {
                    System.Console.WriteLine(warning);
                }

                System.Console.WriteLine("\nYour text: ");
                userMessage = Console.ReadLine();

                writingOptions.ClearAndWriteToFile(userInput, userMessage, TextFileName);
                break;


            case UserOptions.AppendToEndOfFile:
                if (FileContents == null)
                {
                    System.Console.WriteLine(warning);
                }

                System.Console.WriteLine("\nYour text: ");
                userMessage = Console.ReadLine();

                writingOptions.AppendToTheEndOfTheFile(userInput, userMessage, TextFileName);
                break;


            case UserOptions.AppendToBeginningOfFile:
                if (FileContents == null)
                {
                    System.Console.WriteLine(warning);
                }

                System.Console.WriteLine("\nYour text: ");
                userMessage = Console.ReadLine();

                writingOptions.AppendToBeginningOfFile(userInput, userMessage, TextFileName);
                break;


            case UserOptions.ClearFile:
                string warning2 = "You have NOT read a file. Please read one before clearing a file of all its data. This stops an empty File from being created. Did not create a file.\n";
                if (FileContents == null)
                {
                    System.Console.WriteLine(warning2);
                    break;
                }
                else
                {
                    bool exitLoop = false;
                    do
                    {
                        string lastWarning;
                        System.Console.WriteLine("Are you sure you want to erase all data from the file? [Y]es or [N]o: \n");
                        lastWarning = System.Console.ReadLine();

                        if (lastWarning.ToUpper() == "Y")
                        {
                            System.Console.WriteLine("Cleared file.\n");
                            writingOptions.ClearFile(userInput, TextFileName);
                            exitLoop = true;
                        }
                        else if (lastWarning.ToUpper() == "N")
                        {
                            System.Console.WriteLine("Aborted clearing file. File NOT modified.\n");
                            exitLoop = true;
                        }
                        else
                        {
                            System.Console.WriteLine("Please input one of two options.\n");
                        }

                        
                    } while (!exitLoop);
                    break;
                    
                }
                

        }
    }

    

    UserOptions UserWriteOptions()
    {
        string userInputOptions = "";
        do
        {
            System.Console.WriteLine("\nTo overwrite the contents of the file, enter [1] \nTo append to the end of the file, enter [2] \nTo Append to the beginning of the file, enter [3] \nTo clear the file completely, enter [4]");

            userInputOptions = System.Console.ReadLine();

            switch (userInputOptions)
            {
                case "1":
                    return UserOptions.ClearAndWriteToFile;

                case "2":
                    return UserOptions.AppendToEndOfFile;

                case "3":
                    return UserOptions.AppendToBeginningOfFile;

                case "4":
                    return UserOptions.ClearFile;
            }
        } while (true);
    }
}