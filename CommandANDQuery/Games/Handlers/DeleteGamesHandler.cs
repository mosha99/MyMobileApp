
global using Resources;
using CommandANDQuery.Games.Commands;
using DAL.Repository;

using Share.Messages;

namespace CommandANDQuery.Games.Handlers;

public class DeleteGameHandler : IRequestHandler<DeleteGameCommand, bool>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public DeleteGameHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<bool> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        bool res = await new DeleteGameQuestionMessage(request?.Game?.Name).Show();

        if (res)
        {
            bool gameId = await RepositoryManager.GameRepository.DeleteGame(request.Game.Id);

            new DeleteCompletMessage().Show();

            return gameId;
        }
        else
        {
            return false;
        }
    }
}
