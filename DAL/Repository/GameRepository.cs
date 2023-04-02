namespace DAL.Repository;

public class GameRepository : IGameRepository
{
    private IAppDbContextBase AppDbContext { set; get; }

    public GameRepository(IAppDbContextBase appDbContext)
    {
        AppDbContext = appDbContext;
    }

    public async Task<List<Game>> GetGames()
    {
        List<Game> games = await AppDbContext.GetItemsAsync<Game>();

        return games;
    }

    public async Task<int> SaveGame(Game game)
    {
        int Gameid = await AppDbContext.SaveItemAsync<Game>(game);
        return Gameid;
    }
    public async Task<bool> DeleteGame(int gameId)
    {
        Game game = await AppDbContext.GetItemAsync<Game>(gameId);

        if (game is not null)
            await AppDbContext.DeleteItemAsync<Game>(game);
        else
            return false;

        return true;
    }
}

public interface IGameRepository
{
    public Task<List<Game>> GetGames();
    public Task<int> SaveGame(Game game);
    public Task<bool> DeleteGame(int gameId);

}


public interface IRepositoryManager
{
    public IGameRepository GameRepository { get; }
}

public class RepositoryManager : IRepositoryManager
{
    private IAppDbContextBase AppDbContext { set; get; }
    private Lazy<IGameRepository> _GameRepository { set; get; }


    public RepositoryManager(IAppDbContextBase appDbContext)
    {
        AppDbContext = appDbContext;
        _GameRepository = new Lazy<IGameRepository>(() => new GameRepository(AppDbContext));
    }

    public IGameRepository GameRepository => _GameRepository.Value;

}