
using Share;
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
    public int GameId { get; set; }
    public string Name { get; set; }
    public int WinCount { get; set; }
    public bool isDeleted { get; set; }

}
public class Person :IModelBase
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool isDeleted { get; set; }
}
public class TransAction :IModelBase
{
    [PrimaryKey , AutoIncrement]
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int Type { get; set; }
    public DateTime BackDate { get; set; }
    public decimal Amount { get; set; }
    public bool isDeleted { get; set; }
}
