using CommandANDQuery.Games.Commands;
using DAL.Repository;
using Models;

namespace CommandANDQuery.Games.Handlers;

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
