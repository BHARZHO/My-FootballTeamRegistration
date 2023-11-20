using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballTeamRegistration
{
    public class Menu
    {
        private readonly IFootballRegistrationManager footballRegistrationManager;

        public Menu()
        {
            footballRegistrationManager = new FootballRegistrationManager();
        }
        
        public void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("====Welcome to my short upbringing football team registration.====");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Enter 1 to Add new player");
            Console.WriteLine("Enter 2 to delete player");
            Console.WriteLine("Enter 3 to update player");
            Console.WriteLine("Enter 4 to search player");
            Console.WriteLine("Enter 5 to get all player");
            Console.WriteLine("Enter 0 to Exit.");
            Console.ResetColor();
        }

        public void MyMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                PrintMenu();
                int option;

                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 0:
                            exit = true;
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Enter player nickname or name: ");
                            var name = Console.ReadLine()!;
                            Console.Write("Enter player preferrd top and short number: ");
                            var shirtNumber = Console.ReadLine()!;
                            Console.Write("Enter player adress: ");
                            var adress = Console.ReadLine()!;
                            var footballPositionInt = Utility.SelectEnum("Select player position:\n1.Goal keeper\n2.Defender\n3.Midfielder\n4.striker: ", 1, 2, 3, 4);
                            var footballPosition = (FootballPosition)footballPositionInt;
                            footballRegistrationManager.AddPlayer(name, shirtNumber, adress, footballPosition);
                            break;
                        case 2:
                            Console.Write("Enter the top or short number of the player you want to delete: ");
                            string shortNumber = Console.ReadLine()!;
                            footballRegistrationManager.DeletePlayer(shortNumber);
                            break;
                        case 3:
                            Console.Write("Enter player name: ");
                            var nameToEdit = Console.ReadLine()!;
                            Console.Write("Enter top or short number: ");
                            var numberToEdit = Console.ReadLine()!;
                            Console.Write("Enter adress: ");
                            var adressToEdit = Console.ReadLine()!;
                            footballRegistrationManager.UpdatePlayer(nameToEdit, numberToEdit, adressToEdit);
                            break;
                        case 4:
                            Console.Write("Enter the top or short number of the player you want to search: ");
                            var search = Console.ReadLine()!;
                            footballRegistrationManager.GetPlayer(search);
                            break;
                        case 5:
                            footballRegistrationManager.GetAllPlayers();
                            Console.ResetColor();
                            break;
                            
                        default:
                            Console.WriteLine("Unknown operation!");
                            break;
                    }

                    if (!exit)
                    {
                        HoldScreen();
                    }
                }
            }
        }

        private void HoldScreen()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}