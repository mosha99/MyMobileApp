namespace DAL;

public interface IAppDbContextBase
{
    public  Task<int> DeleteItemAsync<T>(T item) where T : new();
    public  Task<T> GetItemAsync<T>(int id) where T : IModelBase, new();
    public  Task<List<T>> GetItemsAsync<T>() where T : IModelBase, new();
    public  Task<(int, bool)> SaveItemAsync<T>(T item) where T : IModelBase, new();
}