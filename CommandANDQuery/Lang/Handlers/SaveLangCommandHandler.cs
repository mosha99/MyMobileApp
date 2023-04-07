using CommandANDQuery.Games.Commands;
using DAL.Repository;
using Share.Messages;

namespace CommandANDQuery.Games.Handlers;

public class SaveLangCommandHandler : IRequestHandler<SaveLangCommand>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public SaveLangCommandHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task Handle(SaveLangCommand request, CancellationToken cancellationToken)
    {
        await RepositoryManager.LangSaver.SetCulture(request.culture);
    }
}

