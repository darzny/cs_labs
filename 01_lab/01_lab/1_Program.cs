internal class Program
{
    private static void Main(string[] args)
    {
        Program.MyName();
    }

    private static void MyName()
    {
        string myName;

        Console.WriteLine("Please enter your name");

        myName = Console.ReadLine();

        Console.WriteLine("Hello, {0}", myName);
    }
}
