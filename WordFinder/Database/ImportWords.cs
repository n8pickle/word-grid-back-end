using WordFinder.Models;
using System.Text;
namespace Database;
public class ImportWords {
    private MyDbContext _dbContext;

    public ImportWords(MyDbContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task ImportAllWordsToDb() {
        const Int32 BufferSize = 128;
        using (var fileStream = File.OpenRead(@"./words_alpha.txt")) {
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize)){
            String line = null;
            while((line = streamReader.ReadLine()) != null) {
                var word = new DictionaryWord();
                word.Word = line;
                await _dbContext.Words.AddAsync(word);
                await _dbContext.SaveChangesAsync();
            }
            }
        }
    }
}