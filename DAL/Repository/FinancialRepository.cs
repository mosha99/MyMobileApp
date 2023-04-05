using Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository;

public class FinancialRepository
{
    private IAppDbContextBase AppDbContext { set; get; }

    public FinancialRepository(IAppDbContextBase appDbContext)
    {
        AppDbContext = appDbContext;
    }


    public async Task<List<TransAction>> GetActions()
    {
        var TransActions = await AppDbContext.GetItemsAsync<TransAction>();
        return TransActions;
    }
    public async Task<List<TransAction>> GetActions(int personId)
    {
        var TransActions = (await GetActions()).Where(x=>x.PersonId == personId).ToList();
        return TransActions;
    } 
    public async Task<TransAction> GetAction(int id)
    {
        var TransAction = await AppDbContext.GetItemAsync<TransAction>(id);
        return TransAction;
    }
    public async Task AddAction(int personId, DateTime backdate, decimal amount, TransActionType type)
    {
        await AppDbContext.SaveItemAsync(new TransAction() { PersonId = personId , Amount = amount , BackDate = backdate , Type = (int)type }) ;

    }
    public async Task AddAction(int id)
    {
        var action = await GetAction(id);
        await AppDbContext.DeleteItemAsync(action);
    }
}

public class PersonRepository
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