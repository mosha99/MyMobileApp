using Models;

namespace CommandANDQuery.Games.Commands;

public class ChangeWinCountGameMemberCommand : IRequest<int>
{
    public GameMember GameMember { get; set; }
    public int Count { get; set; }
    public ChangeWinCountGameMemberCommand(GameMember gameMember, int count)
    {
        GameMember = gameMember;
        Count = count;
    }
}