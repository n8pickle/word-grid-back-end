using WordFinder.Hubs;

namespace WordFinder
{
    public interface IWordHubClient
    {
        Task NumPlayersCount(int count);
        Task SendRandomLetters(List<char> letters);
        Task SendIsValidWord(bool word);
        Task SendNerdleWinner(string winner,string player1,string player2, int p1Score, int p2Score, List<string> p1Words, List<string> p2Words);
        Task SendFoundWord(string username);
    }
}
