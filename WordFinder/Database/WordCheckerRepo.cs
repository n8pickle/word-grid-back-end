using Microsoft.EntityFrameworkCore;
namespace Database;
public class WordCheckerRepo {
    private MyDbContext _dbContext;

    public WordCheckerRepo(MyDbContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<bool> checkIfWordExists(string word) {
        if(word.Length < 3) {
            return true;
        }
        var retrieved = await _dbContext.Words.FirstOrDefaultAsync((w) => w.Word == word);
        return retrieved == null;
    }
}