using Microsoft.AspNetCore.SignalR;
using Database;
using WordFinder.Controllers;

namespace WordFinder.Hubs
{
    public class WordHub: Hub<IWordHubClient>
    {
        private WordCheckerRepo _checkerRepo;
        private static int count = 0;
        private static string player1 = "";
        private static string player2 = "";
        private static int player1Score = 0;
        private static int player2Score = 0;
        private List<string> player1List;
        private List<string> player2List;

        public WordHub(WordCheckerRepo checkerRepo) {
            _checkerRepo = checkerRepo;
        }

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
            string w = word.ToLower();
            var wordIsValid = await _checkerRepo.checkIfWordExists(w);
            await Clients.Caller.SendIsValidWord(!wordIsValid);
        }
        public async Task NerdleWinner(string username, int score, List<string> wordsFound)
        {
            if (username == player1)
            {
                player1Score = score;
                if (wordsFound != null)
                {
                    player1List = wordsFound;
                }
                
            }
            if(username == player2)
            {
                player2Score = score;
                if (wordsFound != null)
                {
                    player2List = wordsFound;
                }
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
                winner = player2 + " WINS!"; ;
            await Clients.All.SendNerdleWinner(winner,player1,player2, player1Score, player2Score, player1List, player2List);
        }
        public async Task FoundWord(string username)
        {
            await Clients.Others.SendFoundWord(username + " found a word.");  
        }     
    }
}
