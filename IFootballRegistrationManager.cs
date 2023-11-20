using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballTeamRegistration
{
    public interface IFootballRegistrationManager
    {
        void AddPlayer(string name, string shirtNumber, string adress, FootballPosition footballPosition);
        FootballRegistration? FindPlayer(string shirtNumber);
        void UpdatePlayer(string shirtNumber, string name, string adress);
        void GetAllPlayers();
        void GetPlayer(string shirtNumber);
        void DeletePlayer(string shirtNumber);
    }
}