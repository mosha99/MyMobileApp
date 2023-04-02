
using CommandANDQuery.Commands;
using DAL.Repository;
using Models;

namespace CommandANDQuery.Handlers;

public class DeleteGameHandler : IRequestHandler<DeleteGameCommand, bool>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public DeleteGameHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<bool> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        bool gameId = await RepositoryManager.GameRepository.DeleteGame(request.Game.Id);
        return gameId;
    }
}
