
namespace Models;

public class Game : IModelBase
{ 
    [PrimaryKey]
    public int Id { get; set; }
    public string Name { get; set; }
    public int TotalRunds => GameMembers.Sum(x => x.WinCount);
    public List<GameMember> GameMembers { get; set; }
    public bool isDeleted { get; set; }

}
public class GameMember :IModelBase
{
    [PrimaryKey]
    public int Id { get; set; }
    public int GameMemberId { get; set; }
    public string Name { get; set; }
    public int WinCount { get; set; }
    public bool isDeleted { get; set; }

}
