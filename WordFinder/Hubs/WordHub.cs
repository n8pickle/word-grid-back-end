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

        public async Task ValidateWord(string word){
            //database call needs to be implemented
            string querySql = "SELECT * FROM Words WHERE word = " + word;
            int result = 1; //result will actually be the result of the query

            bool validWord;
            if(result > 0){
                validWord = true;
            }else{
                validWord = false;
            }
            await Clients.All.IsWordValid(validWord);
        }
    }
}
