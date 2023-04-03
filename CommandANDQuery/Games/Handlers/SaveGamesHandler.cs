using CommandANDQuery.Games.Commands;
using DAL.Repository;
using Models;

namespace CommandANDQuery.Games.Handlers;

public class SaveGameHandler : IRequestHandler<SaveGameCommand, int>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public SaveGameHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<int> Handle(SaveGameCommand request, CancellationToken cancellationToken)
    {

        var Result = await RepositoryManager.GameRepository.SaveGame(request.Game);

        string message;

        if (Result.isNew)
        {
            message = LangResource.GameAdded;
        }
        else
        {
            message = LangResource.GameEdited;
        }

        request.ShowMessage(new MessageInfo(MessageType.Sucsses, string.Format(message, request?.Game?.Name)));

        return Result.id;
    }
}

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

        if (Result.isNew)
        {
            message = LangResource.GameMemberAdded;
        }
        else
        {
            message = LangResource.GameMemberEdited;
        }

        request.ShowMessage(new MessageInfo(MessageType.Sucsses, string.Format(message, request?.GameMember?.Name)));

        return Result.id;
    }
}

