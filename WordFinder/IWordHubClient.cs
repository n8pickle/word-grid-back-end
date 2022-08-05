using WordFinder.Hubs;

namespace WordFinder
{
    public interface IWordHubClient
    {
        Task NumPlayersCount(int count);
        Task SendRandomLetters(List<char> letters);
        Task SendIsValidWord(bool word);
        Task SendNerdleWinner(string winner);
    }
}
