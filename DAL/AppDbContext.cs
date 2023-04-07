global using Models;
using SQLite;
using System.Linq.Expressions;

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
        var result2 = await Database.CreateTableAsync<GameMember>();
        var result3 = await Database.CreateTableAsync<Person>();
        var result4 = await Database.CreateTableAsync<TranCAction>();
        var result5 = await Database.CreateTableAsync<SelectedCulture>();
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

    public async Task<(int, bool)> SaveItemAsync<T>(T item) where T : IModelBase, new()
    {
        await Init();

        if (item.Id != 0)
            return new(await Database.UpdateAsync(item), false);
        else

            return new(await Database.InsertAsync(item), true);
    }

    public async Task<int> DeleteItemAsync<T>(T item) where T : new()
    {
        await Init();
        return await Database.DeleteAsync(item);
    }
    public async Task<List<T>> FindByCondition<T>(Expression<Func<T, bool>> expression) where T : new()
    {
        await Init();
        return await Database.Table<T>().Where(expression).ToListAsync();
    }

}
