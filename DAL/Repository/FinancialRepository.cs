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
