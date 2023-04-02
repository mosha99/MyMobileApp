
using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Game : IModelBase
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public int TotalRunds{ get; set; }
    public bool isDeleted { get; set; }

}
public class GameMember :IModelBase
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int GameMemberId { get; set; }
    public string Name { get; set; }
    public int WinCount { get; set; }
    public bool isDeleted { get; set; }

}
