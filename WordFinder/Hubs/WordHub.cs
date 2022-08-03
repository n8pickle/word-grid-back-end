using Microsoft.AspNetCore.SignalR;
using RestSharp;
using WordFinder.Models;
using WordFinder.Controllers;

namespace WordFinder.Hubs
{
    public class WordHub: Hub<IWordHubClient>
    {
        public static int count = 0;
        public async Task NumPlayers()
        {
            count++;
            await Clients.All.NumPlayersCount(count);
        }
        public async Task GetLetters()
        {
            if (count == 2)
            {
                RandomLetter randomLetter = new RandomLetter();
                List<char> letters = randomLetter.getLetters();
                await Clients.All.SendRandomLetters(letters);
            }
            
        }
    }
}
