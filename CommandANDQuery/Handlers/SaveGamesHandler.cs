
using CommandANDQuery.Commands;
using DAL.Repository;
using Models;

namespace CommandANDQuery.Handlers;

public class SaveGameHandler : IRequestHandler<SaveGameCommand, int>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public SaveGameHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<int> Handle(SaveGameCommand request, CancellationToken cancellationToken)
    {
        int gameId = await RepositoryManager.GameRepository.SaveGame(request.Game);
        return gameId;
    }
}
