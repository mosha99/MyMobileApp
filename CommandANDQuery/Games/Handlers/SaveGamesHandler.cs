using CommandANDQuery.Games.Commands;
using DAL.Repository;
using Models;
using Share.Messages;

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

        new SuccessMessage().Show();

        return Result.id;
    }
}

