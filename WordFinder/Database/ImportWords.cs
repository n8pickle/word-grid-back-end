namespace Database;
public class ImportWords {
    
    public void ImportWordsFromTextFile(){
        
        foreach (string word in System.IO.File.ReadLines("words_alpha.txt")){
            //insert the words
            //INSERT INTO words Value (word)
        }

        //delete words.txt after?

    }

}