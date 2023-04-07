using System.Globalization;
using System.Linq.Expressions;

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

        foreach (var item in games)
        {
            item.TotalRunds = (await GetGameMembers(item.Id)).Sum(x => x.WinCount);
        }
        return games;
    }

    public async Task<(int, bool)> SaveGame(Game game)
    {
        var result = await AppDbContext.SaveItemAsync<Game>(game);
        return result;
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

    public async Task<List<GameMember>> GetGameMembers(int gameId)
    {
        List<GameMember> games = await AppDbContext.GetItemsAsync<GameMember>();
        games = games.Where(x => x.GameId == gameId).ToList();
        return games;
    }

    public async Task<(int, bool)> SaveGameMember(GameMember game)
    {
        var result = await AppDbContext.SaveItemAsync<GameMember>(game);
        return result;
    }
    public async Task<bool> DeleteGameMember(int gameMemberid)
    {
        GameMember gameMember = await AppDbContext.GetItemAsync<GameMember>(gameMemberid);

        if (gameMember is not null)
            await AppDbContext.DeleteItemAsync<GameMember>(gameMember);
        else
            return false;

        return true;
    }

    public async Task<int> ChangeWinCountGameMember(int gameMemberId, int count)
    {
        List<GameMember> gameMembers = await AppDbContext.GetItemsAsync<GameMember>();

        var gameMember = gameMembers.Single(x => x.Id == gameMemberId);

        gameMember.WinCount += count;

        await SaveGameMember(gameMember);

        return gameMember.Id;
    }
}
