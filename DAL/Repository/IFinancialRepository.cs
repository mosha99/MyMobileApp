using Share;

namespace DAL.Repository;

public interface IFinancialRepository
{
    public  Task<List<TranCAction>> GetActions();
    public  Task<List<TranCAction>> GetActions(int personId);
    public  Task<TranCAction> GetAction(int id);
    public  Task AddAction(int personId, DateTime backdate, decimal amount, TranCActionType type);
    public  Task DeleteAction(int id);
    public  Task PayedAction(int id);

}