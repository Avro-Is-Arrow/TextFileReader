ReadingAndWriting readingAndWriting = new ReadingAndWriting("lelelet");
readingAndWriting.ReadFile();

System.Console.WriteLine(readingAndWriting.FileContents);

System.Console.WriteLine("Writing to file: \n");

readingAndWriting.WriteFile();