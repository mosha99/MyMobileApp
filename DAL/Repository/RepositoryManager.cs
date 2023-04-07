using System.Linq.Expressions;

namespace DAL.Repository;

public class RepositoryManager : IRepositoryManager
{
    private IAppDbContextBase AppDbContext { set; get; }
    private Lazy<IGameRepository> _GameRepository { set; get; }
    private Lazy<IPersonRepository> _PersonRepository { set; get; }
    private Lazy<ILangSaver> _LangSaver { set; get; }
    private Lazy<IFinancialRepository> _FinancialRepository { set; get; }

    public RepositoryManager(IAppDbContextBase appDbContext)
    {
        AppDbContext = appDbContext;
        _GameRepository = new Lazy<IGameRepository>(() => new GameRepository(AppDbContext));
        _PersonRepository = new Lazy<IPersonRepository>(() => new PersonRepository(AppDbContext));
        _LangSaver = new Lazy<ILangSaver>(() => new LangSaver(AppDbContext));
        _FinancialRepository = new Lazy<IFinancialRepository>(() => new FinancialRepository(AppDbContext));
    }

    public IGameRepository GameRepository => _GameRepository.Value;
    public IPersonRepository PersonRepository => _PersonRepository.Value;
    public IFinancialRepository FinancialRepository => _FinancialRepository.Value;
    public ILangSaver LangSaver => _LangSaver.Value;

    public async Task<bool> Exist<T>(Expression<Func<T, bool>> expression) where T : new()
    {
        var itemList = await AppDbContext.FindByCondition(expression);
        return itemList.Any();
    }
}