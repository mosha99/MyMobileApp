using System.Linq.Expressions;

namespace DAL;

public interface IAppDbContextBase
{
    public Task<int> DeleteItemAsync<T>(T item) where T : new();
    public Task<T> GetItemAsync<T>(int id) where T : IModelBase, new();
    public Task<List<T>> GetItemsAsync<T>() where T : IModelBase, new();
    public Task<List<T>> FindByCondition<T>(Expression<Func<T, bool>> expression) where T : new();
    public Task<(int, bool)> SaveItemAsync<T>(T item) where T : IModelBase, new();
}