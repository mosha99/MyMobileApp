using Models;

namespace CommandANDQuery.Games.Commands
{
    public class SaveGameMemberCommand : IRequest<int>
    {
        public GameMember GameMember { get; set; }
        public SaveGameMemberCommand(GameMember gameMember)
        {
            GameMember = gameMember;
        }
    }
}
