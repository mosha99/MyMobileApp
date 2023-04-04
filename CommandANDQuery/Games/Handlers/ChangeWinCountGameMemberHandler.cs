using CommandANDQuery.Games.Commands;
using DAL.Repository;
using Share.Messages;

namespace CommandANDQuery.Games.Handlers;

public class ChangeWinCountGameMemberHandler : IRequestHandler<ChangeWinCountGameMemberCommand, int>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public ChangeWinCountGameMemberHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<int> Handle(ChangeWinCountGameMemberCommand request, CancellationToken cancellationToken)
    {

        string message = string.Format(LangResource.GameMemberDeleteQuestion, request?.GameMember?.Name);

        int gameMemberId = await RepositoryManager.GameRepository.ChangeWinCountGameMember(request.GameMember.Id, request.Count);

        new SuccessMessage().Show();

        return gameMemberId;

    }
}
