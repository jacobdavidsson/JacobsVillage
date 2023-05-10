namespace JacobsVillage
{
    public class Program
    {
        static void Main(string[] args)
        {
            Village village = new Village();

            while (true)
            {
                UserInput.printMenu(village.getDaysGone());

                int userInput = Convert.ToInt32(Console.ReadLine());
                UserInput.menuChoice(village, userInput);

                Console.WriteLine();
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();

                UserInput.printVillageInfo(village);


                if (village.CastleisBuilt())
                {
                    Environment.Exit(0);
                }
            }

        }
    }
}