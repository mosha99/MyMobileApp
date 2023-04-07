using CommandANDQuery.Games.Commands;
using DAL.Repository;
using Models;
using System.Globalization;

namespace CommandANDQuery.Games.Handlers;

public class GetLangHandler : IRequestHandler<GetLangCommand , CultureInfo>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public GetLangHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<CultureInfo> Handle(GetLangCommand request, CancellationToken cancellationToken)
    {
        CultureInfo culture = await RepositoryManager.LangSaver.GetCulture();
        return culture;
    }
}
