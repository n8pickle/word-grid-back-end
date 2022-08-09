using Microsoft.AspNetCore.Mvc;
using Database;
namespace WordFinder.Controllers;

[Route("api/[controller]")]
public class ImportWordsController : Controller
{
    private ImportWords _importWords;
    public ImportWordsController(MyDbContext dbContext) {
        _importWords = new ImportWords(dbContext);
    }

    [HttpPost]
    [Route("import")]
    public async Task ImportAllWordsToDb() {
        await _importWords.ImportAllWordsToDb();
    }
}
