using System;
using System.IO;
    
class FileDetails 
{
    static void Summarize(char[] contents)
    {
        int vovels = 0, consonants = 0, lines = 0;

        foreach (char current in contents)
        {
            if (Char.IsLetter(current))
            {
                if ("AEIOUaeiou".IndexOf(current) != 1)
                {
                    vovels++;
                } else
                {
                    consonants++;
                }
            }
            else if (current == '\n')
            {
                lines++;
            }
        }

        Console.WriteLine($"Total no of characters: {contents.Length}");

        Console.WriteLine($"Total no of vovels: {vovels}");
        Console.WriteLine($"Total no of consonants: {consonants}");
        Console.WriteLine($"Total no of lines: {lines}");
    }

    static void Main1(string[] args) 
	{
        Console.WriteLine(args.Length);

        foreach (string arg in args)
        {
            Console.WriteLine($"{arg} ");
        }

        string fileName = args[0];

        FileStream stream = new FileStream(fileName, FileMode.Open);
        StreamReader reader = new StreamReader(stream);

        int size = (int)stream.Length;
        char[] contents = new char[size];

        for (int i = 0; i < size; i++)
        {
            contents[i] = (char)reader.Read();
        }

        foreach(char ch in contents)
        {
            Console.Write(ch);
        }
    }
}
