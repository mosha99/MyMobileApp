using SQLite;

namespace Models;

public class TranCAction :IModelBase
{
    [PrimaryKey , AutoIncrement]
    public int Id { get; set; }
    public bool NotifSended { get; set; }
    public int PersonId { get; set; }
    public int Payed { get; set; }
    public int Type { get; set; }
    public DateTime BackDate { get; set; }
    public decimal Amount { get; set; }
    public bool isDeleted { get; set; }
}
