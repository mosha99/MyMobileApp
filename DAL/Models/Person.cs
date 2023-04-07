using SQLite;

namespace Models;

public class Person :IModelBase
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public bool isDeleted { get; set; }
}
