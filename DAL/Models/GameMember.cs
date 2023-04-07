using SQLite;

namespace Models;

public class GameMember :IModelBase
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int GameId { get; set; }
    public string Name { get; set; }
    public int WinCount { get; set; }
    public bool isDeleted { get; set; }

}
