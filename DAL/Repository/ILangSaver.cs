using System.Globalization;

namespace DAL.Repository;

public interface ILangSaver
{
    Task<CultureInfo> GetCulture();
    Task SetCulture(string Culture = "en-us");
}
