using MyMobileApp.Shared;
using Share;

namespace MyMobileApp.Adapters
{
    public class MainLayoutAdapter : IMyPage
    {
        private MainLayout MainLayout { get; set; }

        public MainLayoutAdapter(MainLayout mainLayout)
        {
            MainLayout = mainLayout;
        }

        public async Task InvokeAsync(Action action) => await MainLayout._InvokeAsync(action);
        public void StateHasChanged() => MainLayout._StateHasChanged();
    }
}
