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

public class GetGameMembersHandler : IRequestHandler<GetGameMembersCommand, List<GameMember>>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public GetGameMembersHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<List<GameMember>> Handle(GetGameMembersCommand request, CancellationToken cancellationToken)
    {
        List<GameMember> gameMembers = await RepositoryManager.GameRepository.GetGameMembers(request.GameId);
        return gameMembers;
    }
}
