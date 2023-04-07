using DAL;
using DAL.Repository;
using CommandANDQuery.Financial.Validators;
using MediatR;
using FluentValidation;

namespace MyMobileApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif
        builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(CommandANDQuery.AssemblyGetter.assembly));

        builder.Services.AddSingleton<IAppDbContextBase, AppDbContext>();

        builder.Services.AddSingleton<IRepositoryManager, RepositoryManager>();

        builder.Services.AddValidatorsFromAssembly(CommandANDQuery.AssemblyGetter.assembly);

        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return builder.Build();
    }
}
