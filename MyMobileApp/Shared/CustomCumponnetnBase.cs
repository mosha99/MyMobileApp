using CommandANDQuery;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace MyMobileApp.Shared;

public abstract class CustomCumponnetnBase : ComponentBase
{
    public async Task ExicuteCumand<T>(IRequest<T> request)
    {

        Func<Task> action = async () =>
        {
            await GetSender().Send(request);
            await AfterExicute();
        };
        await Exicuting(request, action);

    }
    public virtual async Task Exicuting<T>(IRequest<T> request, Func<Task> exicute)
    {
        await exicute();
    }

    public abstract ISender GetSender();
    public abstract Task AfterExicute();
}

