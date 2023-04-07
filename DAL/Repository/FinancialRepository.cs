using Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository;

public class FinancialRepository : IFinancialRepository
{
    private IAppDbContextBase AppDbContext { set; get; }

    public FinancialRepository(IAppDbContextBase appDbContext)
    {
        AppDbContext = appDbContext;
    }

    public async Task<List<TranCAction>> GetActions()
    {
        var TranCActions = await AppDbContext.GetItemsAsync<TranCAction>();
        TranCActions.ForEach(x =>
        {
            if (x.Type == 1)
                x.Amount *= -1;
        });
        return TranCActions;
    }
    public async Task<List<TranCAction>> GetActions(int personId)
    {
        var TranCActions = (await GetActions()).Where(x => x.PersonId == personId).ToList();
        return TranCActions;
    }
    public async Task<TranCAction> GetAction(int id)
    {
        var TranCAction = await AppDbContext.GetItemAsync<TranCAction>(id);
        return TranCAction;
    }
    public async Task AddAction(int personId, DateTime backdate, decimal amount, TranCActionType type)
    {
        await AppDbContext.SaveItemAsync(new TranCAction() { PersonId = personId, Amount = amount, BackDate = backdate, Type = (int)type, Payed = (int)TranCActionState.NotPayed });

    }
    public async Task DeleteAction(int id)
    {
        var action = await GetAction(id);
        await AppDbContext.DeleteItemAsync(action);
    }

    public async Task PayedAction(int id)
    {
        var action = await GetAction(id);
        action.Payed = (int)TranCActionState.Payed;
        await AppDbContext.SaveItemAsync(action);
    }
}
