namespace DAL.Repository;

public class PersonRepository: IPersonRepository
{
    private IAppDbContextBase AppDbContext { set; get; }

    public PersonRepository(IAppDbContextBase appDbContext)
    {
        AppDbContext = appDbContext;
    }
    public async Task<Person> GetPerson(int id)
    {
        var person = await AppDbContext.GetItemAsync<Person>(id);
        return person;
    }
    public async Task<List<Person>> GetPeople()
    {
        var persons = await AppDbContext.GetItemsAsync<Person>();
        return persons;
    }
    public async Task AddPerson(string Name)
    {
        await AppDbContext.SaveItemAsync(new Person() { Name = Name });
    }
    public async Task UpdatePerson(string Name, int id)
    {
        await AppDbContext.SaveItemAsync(new Person() {Id = id, Name = Name });
    }
    public async Task DeletePerson(int id)
    {
        var person = await GetPerson(id);
        await AppDbContext.DeleteItemAsync(person);
    }

}
public interface IPersonRepository
{
    public Task<Person> GetPerson(int id);
    public Task<List<Person>> GetPeople();
    public Task AddPerson(string Name);
    public Task UpdatePerson(string Name, int id);
    public Task DeletePerson(int id);
}