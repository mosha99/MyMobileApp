using System.Linq.Expressions;

namespace DAL.Repository;

public interface IRepositoryManager
{
    public IGameRepository GameRepository { get; }
    public IPersonRepository PersonRepository { get; }
    public IFinancialRepository FinancialRepository { get; }
    public ILangSaver LangSaver { get; }
    public Task<bool> Exist<T>(Expression<Func<T, bool>> expression) where T : new();
}
