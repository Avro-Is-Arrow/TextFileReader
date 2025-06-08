ReadingAndWriting readingAndWriting = new ReadingAndWriting("FILE'S NAME HERE!!");
readingAndWriting.ReadFile();

System.Console.WriteLine(readingAndWriting.FileContents);

System.Console.WriteLine("Writing to file: \n");

readingAndWriting.WriteFile();