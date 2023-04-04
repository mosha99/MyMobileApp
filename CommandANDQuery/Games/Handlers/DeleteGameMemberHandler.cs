using CommandANDQuery.Games.Commands;
using DAL.Repository;
using Share.Messages;

namespace CommandANDQuery.Games.Handlers;

public class DeleteGameMemberHandler : IRequestHandler<DeleteGameMemberCommand, bool>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public DeleteGameMemberHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<bool> Handle(DeleteGameMemberCommand request, CancellationToken cancellationToken)
    {

        bool res = await new DeleteGameMemberQuestionMessage(request?.GameMember?.Name).Show();

        if (res)
        {
            bool gameMemberId = await RepositoryManager.GameRepository.DeleteGameMember(request.GameMember.Id);

            new DeleteCompletMessage().Show();

            return gameMemberId;
        }
        else
        {
            return false;
        }
    }
}
