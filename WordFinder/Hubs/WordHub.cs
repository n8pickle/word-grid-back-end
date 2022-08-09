using Microsoft.AspNetCore.SignalR;
using WordFinder.Models;
using WordFinder.Controllers;

namespace WordFinder.Hubs
{
    public class WordHub: Hub<IWordHubClient>
    {
        private static int count = 0;
        private static string player1 = "";
        private static string player2 = "";
        private static int player1Score = 0;
        private static int player2Score = 0;

        public async Task NumPlayers(string username)
        {
            count++;
            if (count == 1)
            {
                player1 = username;
            }
            if(count == 2)
            {
                player2 = username;
            }
            await Clients.All.NumPlayersCount(count);
        }
        public async Task GetLetters()
        {
            RandomLetter randomLetter = new RandomLetter();
            List<char> letters = randomLetter.getLetters();
            await Clients.All.SendRandomLetters(letters);
        }
        public async Task IsValidWord(string word)
        {
            //todo: make a check against the database to see if the word is valid.

            await Clients.All.SendIsValidWord(true);
        }
        public async Task NerdleWinner(string username, int score)
        {
            if (username == player1)
            {
                player1Score = score;
            }
            if(username == player2)
            {
                player2 = username;
                player2Score = score;
            }

            string winner = "";
            if (player1Score == player2Score)
            {
                winner = "YOU TIED!";
            }
            else if (player1Score > player2Score)
            {
                winner = player1 + " WINS!";
            }
            else
                winner = player2 + " WINS!";
            await Clients.All.SendNerdleWinner(winner);
            
        }
        public async Task OpponentFoundWord(string username)
        {
            await Clients.Others.SendOpponentFoundWord(username + " found a word.");
        }
     
    }
}
