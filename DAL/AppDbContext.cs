global using Models;
using SQLite;

namespace DAL;

public class AppDbContext : IAppDbContextBase
{

    SQLiteAsyncConnection Database;

    public AppDbContext()
    {
    }

    async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Database.CreateTableAsync<Game>();
    }

    public async Task<List<T>> GetItemsAsync<T>() where T : IModelBase, new()
    {
        await Init();
        return await Database.Table<T>().ToListAsync();
    }

    public async Task<T> GetItemAsync<T>(int id) where T : IModelBase, new()
    {
        await Init();
        return await Database.Table<T>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync<T>(T item) where T : IModelBase, new()
    {
        await Init();
        if (item.Id != 0)
            return await Database.UpdateAsync(item);
        else
            return await Database.InsertAsync(item);
    }

    public async Task<int> DeleteItemAsync<T>(T item) where T : new()
    {
        await Init();
        return await Database.DeleteAsync(item);
    }
}
