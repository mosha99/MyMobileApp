using CommandANDQuery.Games.Commands;
using DAL.Repository;
using Share.Messages;

namespace CommandANDQuery.Games.Handlers;

public class SaveGameMemberHandler : IRequestHandler<SaveGameMemberCommand, int>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public SaveGameMemberHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<int> Handle(SaveGameMemberCommand request, CancellationToken cancellationToken)
    {

        var Result = await RepositoryManager.GameRepository.SaveGameMember(request.GameMember);

        string message;

        new SuccessMessage().Show();

        return Result.id;
    }
}

