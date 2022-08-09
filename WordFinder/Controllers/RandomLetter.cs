namespace WordFinder.Controllers
{
    public class RandomLetter
    {
        
        List<char> letter = new List<char>();
        List<string> dice = new List<string>()
        {
            "RIFOBXIBRO", "IFEHFYHEYE", "SNODENOWSE","KUTOKNUDOT",
            "AOHMSRAOSM", "ELUPETSTUS", "AICTACITOT","EYLEGKYKLUE",
            "OABQBMJOAJ", "EHISPNEHPI", "VETIGNEITG", "BALIYTBALI",
            "EZAVNDEZAD", "RALESCRALE", "UWILRGUWIL", "PACEMDPACE"
        };
        

        
        public List<char> getLetters()
        {
            for (int i = 0; i < 16; i++)
            {
                //Get a random dice 
                Random random = new Random();
                int index = random.Next(0,dice.Count());
                //Get a random letter from dice
                Random r = new Random();
                int randomLetter = r.Next(0,10);
                char ch = dice[index][randomLetter];
                
                dice.RemoveAt(index);
                
                if(ch == 'Q' && i != 15)
                {
                    letter.Add(ch);
                    letter.Add('U');
                    i++;
                }
                else
                    letter.Add(ch);
            }
            return letter;
        }
     
    }
}
