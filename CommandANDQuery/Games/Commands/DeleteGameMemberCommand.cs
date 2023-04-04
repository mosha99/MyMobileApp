using Models;

namespace CommandANDQuery.Games.Commands;

public class DeleteGameMemberCommand : IRequest<bool>
{
    public GameMember GameMember { get; set; }
    public DeleteGameMemberCommand(GameMember gameMember)
    {
        GameMember = gameMember;
    }
}
