using CommandANDQuery.Games.Commands;
using DAL.Repository;
using Models;

namespace CommandANDQuery.Games.Handlers;

public class GetGamesHandler : IRequestHandler<GetGamesCommand, List<Game>>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public GetGamesHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<List<Game>> Handle(GetGamesCommand request, CancellationToken cancellationToken)
    {
        List<Game> games = await RepositoryManager.GameRepository.GetGames();
        return games;
    }
}
