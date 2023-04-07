using System.Globalization;

namespace DAL.Repository;

public class LangSaver : ILangSaver
{
    private IAppDbContextBase AppDbContext { set; get; }
    public LangSaver(IAppDbContextBase appDbContext)
    {
        AppDbContext = appDbContext;
    }

    public async Task<CultureInfo> GetCulture()
    {
        var selectedCulture = await AppDbContext.GetItemsAsync<SelectedCulture>();

        if (!selectedCulture.Any())
        {
            await SetCulture();
            selectedCulture = await AppDbContext.GetItemsAsync<SelectedCulture>();
        }

        return new CultureInfo(selectedCulture.Single().Culture);

    }

    public async Task SetCulture(string Culture = "en-us")
    {
        var selectedCulture = await AppDbContext.GetItemsAsync<SelectedCulture>();

        if (!selectedCulture.Any())
        {
            await AppDbContext.SaveItemAsync(new SelectedCulture() { Culture = Culture });
        }
        else
        {
            selectedCulture = await AppDbContext.GetItemsAsync<SelectedCulture>();
            var item = selectedCulture.Single();
            item.Culture = Culture;
            await AppDbContext.SaveItemAsync(item);
        }
    }

}
