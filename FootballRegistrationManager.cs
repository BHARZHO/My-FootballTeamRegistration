using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTables;
using Humanizer;

namespace FootballTeamRegistration
{
    internal sealed class FootballRegistrationManager : IFootballRegistrationManager
    {
        public static List<FootballRegistration> FootballRegistrations = new();
        public void AddPlayer(string name, string shirtNumber, string adress, FootballPosition footballPosition)
        {
            int id = FootballRegistrations.Count > 0 ? FootballRegistrations.Count + 1 : 1;

            var isFootballRegistrationExist = IsFootballRegistrationExist(shirtNumber);

            if (isFootballRegistrationExist)
            {
                Console.WriteLine("Player registration alredy exist");
                return;
            }


            var footballRegistration = new FootballRegistration
            {
                Id = id,
                Name = name,
                ShirtNumber = shirtNumber,
                Adress = adress,
                FootballPosition = footballPosition,
                CreatedAt = DateTime.Now
            };

            FootballRegistrations.Add(footballRegistration);
            Console.WriteLine("Player added succesfully.");
        }

        public void DeletePlayer(string shirtNumber)
        {
            var footballRegistration = FindPlayer(shirtNumber);

            if (footballRegistration is null)
            {
                Console.WriteLine("Unable to delete player as it does not exist!");
                return;
            }

            FootballRegistrations.Remove(footballRegistration);
        }

        public FootballRegistration? FindPlayer(string shirtNumber)
        {
            return FootballRegistrations.Find(c => c.ShirtNumber == shirtNumber);
        }

        public void GetAllPlayers()
        {
            int footballRegistrationCount = FootballRegistrations.Count;

            Console.WriteLine("You have " + "player".ToQuantity(footballRegistrationCount));

            if (footballRegistrationCount == 0)
            {
                Console.WriteLine("There is no contact added yet.");
                return;
            }

            var table = new ConsoleTable("Id", "Name", "Shirt Number", "Adress", "Football Position", "Date Created");

            foreach (var footballRegistration in FootballRegistrations)
            {
                table.AddRow(footballRegistration.Id, footballRegistration.Name, footballRegistration.ShirtNumber, footballRegistration.Adress, ((FootballPosition)footballRegistration.FootballPosition).Humanize(), footballRegistration.CreatedAt.Humanize());
            }

            table.Write(Format.Alternative);
        }

        public void GetPlayer(string shirtNumber)
        {
            var footballRegistration = FindPlayer(shirtNumber);

            if (footballRegistration is null)
            {
                Console.WriteLine($"Contact with {shirtNumber} not found");
            }
            else
            {
                Print(footballRegistration);
            }
        }

        public void UpdatePlayer(string shirtNumber, string name, string adress)
        {
            var footballRegistration = FindPlayer(shirtNumber);

            if (footballRegistration is null)
            {
                Console.WriteLine("Player does not exist!");
                return;
            }

            footballRegistration.Name = name;
            footballRegistration.Adress = adress;
            Console.WriteLine("Player updated sucessfully.");
        }

        private void Print(FootballRegistration footballRegistration)
        {
            Console.WriteLine($"Name: {footballRegistration!.Name}\nShirt Number: {footballRegistration!.ShirtNumber}\nAdress {footballRegistration!.Adress}");
        }

        private bool IsFootballRegistrationExist(string shirtNumber)
        {
            return FootballRegistrations.Any(c => c.ShirtNumber == shirtNumber);
        }
    }
}