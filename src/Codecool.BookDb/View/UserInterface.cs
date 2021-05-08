using System;

namespace Codecool.BookDb.View
{
    public class UserInterface
    {
        public void PrintLn(Object obj)
        {
            Console.WriteLine(obj);
        }

        public void PrintTitle(string title)
        {
            Console.WriteLine("\n --" + title + " --");
        }

        public void PrintOption(char option, string description)
        {
            Console.WriteLine("(" + option + ")" + " " + description);
        }

        public char Choice(string options)
        {
            // Given string options -> "abcd"
            // keep asking user for input until one of provided chars is provided
            throw new NotImplementedException();
        }

        public string ReadString(string prompt, string defaultValue)
        {
            // Ask user for data. If no data was provided use default value.
            // User must be informed what the default value is.
            throw new NotImplementedException();
        }

        public DateTime ReadDate(string prompt, DateTime defaultValue)
        {
            // Ask user for a date. If no data was provided use default value.
            // User must be informed what the default value is.
            // If provided date is in invalid format, ask user again.
            throw new NotImplementedException();
        }
        
        public int ReadInt(string prompt, int defaultValue)
        {
            // Ask user for a number. If no data was provided use default value.
            // User must be informed what the default value is.
            throw new NotImplementedException();
        }
    }
}
