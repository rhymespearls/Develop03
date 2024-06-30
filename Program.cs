public class Program
{
    public static void Main()
    {
        var scripture = new Scripture("Alma 32:32", "Therefore, if a seed groweth it is good, but if it groweth not, behold it is not good, therefore it is cast away.");

        while (!scripture.IsVerseDone())
        {
           scripture.Display();
                Console.WriteLine("Press Enter to continue or type 'Quit' to exit.");
            var input = Console.ReadLine();

            if (input == "quit")
                break;

            scripture.HideRandomWord();
        }
    }
}