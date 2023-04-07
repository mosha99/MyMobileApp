using SQLite;

namespace Models;

public class SelectedCulture : IModelBase
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Culture { get; set; }
    public bool isDeleted { get; set; }
}
