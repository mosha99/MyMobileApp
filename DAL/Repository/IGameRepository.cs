namespace DAL.Repository;

public interface IGameRepository
{
    public Task<List<Game>> GetGames();
    public Task<(int id, bool isNew)> SaveGame(Game game);
    public Task<bool> DeleteGame(int gameId);

    public Task<List<GameMember>> GetGameMembers(int gameId);
    public Task<(int id, bool isNew)> SaveGameMember(GameMember gameMember);
    public Task<bool> DeleteGameMember(int gameMemberId);
    public Task<int> ChangeWinCountGameMember(int gameMemberId, int Count);

}
