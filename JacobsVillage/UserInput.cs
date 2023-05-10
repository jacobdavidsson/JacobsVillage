using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobsVillage
{
    public class UserInput
    {
        public static void menuChoice(Village village, int userInput)
        {
            switch (userInput)
            {
                case 1: village.AddWorker("name", "wood", village.AddWood);
                    break;
                case 2: village.AddWorker("name", "food", village.AddFood);
                    break;
                case 3: village.AddWorker("name", "metal", village.AddMetal);
                    break;
                case 4: village.AddWorker("name", "builder", village.Build);
                    break;
                case 5: village.AddProject(new House("House"));
                    break;
                case 6: village.AddProject(new Woodmill("Woodmill"));
                    break;
                case 7: village.AddProject(new Quarry("Quarry"));
                    break;
                case 8: village.AddProject(new Farm("Farm"));
                    break;
                case 9: village.AddProject(new Castle("Castle"));
                    break;
                case 10: village.Day();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        public static void printVillageInfo(Village village)
        {
            Console.WriteLine("Wood: " + village.getWood());
            Console.WriteLine("Metal: " + village.getMetal());
            Console.WriteLine("Food: " + village.getFood());
            foreach(IBuilding project in village.getProjects())
            {
                Console.WriteLine($"Project: {project.getName()} {project.getDaysToComplete()}");
            }
            foreach (IBuilding buildings in village.getBuildings())
            {
                Console.WriteLine($"Building: {buildings.getName()}");
            }
            foreach (Worker worker in village.getWorkers())
            {
                Console.WriteLine($"Worker: {worker.getOccupation()}");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void printMenu(int daysGone)
        {
            Console.WriteLine("DAY " + daysGone);
            Console.WriteLine("1. Add wood worker");
            Console.WriteLine("2. Add food worker");
            Console.WriteLine("3. Add metal worker");
            Console.WriteLine("4. Add builder");
            Console.WriteLine("5. Add House");
            Console.WriteLine("6. Add Woodmill");
            Console.WriteLine("7. Add Quarry");
            Console.WriteLine("8. Add Farm");
            Console.WriteLine("9. Add Castle");
            Console.WriteLine("10. Day");
        }
    }
}
