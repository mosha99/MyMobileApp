using CommandANDQuery;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace MyMobileApp.Shared;

public abstract class CustomCumponnetnBase : ComponentBase
{
    static object monitor = new object();
    public int counter = 20;
    public bool? MessageResult = null;
    public bool showMessage = false;
    public MessageInfo messageInfo;

    public void MessageResponse(bool response)
    {
        MessageResult = response;
        HideMessage();
    }
    public void HideMessage()
    {
        this.InvokeAsync(() =>
        {
            showMessage = false;
            this.StateHasChanged();
        });
    }
    public async Task<bool> ShowMessage(MessageInfo massageInfo)
    {
       Monitor.Enter(monitor);

        try
        {
            this.messageInfo = massageInfo;

            showMessage = true;

            counter = massageInfo.Counter;

            bool result = await Task.Run(Getesult);

            MessageResult = null;

            HideMessage();

            return result;
        }
        finally
        {
            Monitor.Exit(monitor);
        }

    }
    public bool Getesult()
    {
        for (int i; counter >= 1; counter--)
        {
            if (MessageResult.HasValue)
                return MessageResult.Value;

            Thread.Sleep(TimeSpan.FromSeconds(1));

            this.InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }
        return false;
    }
    public async Task ExicuteCumand<T>(CustomRequest<T> request)
    {

        request.ShowMessage = ShowMessage;

        T Result = await GetSender().Send(request);

        await AfterExicute(request);

    }
    public abstract Task AfterExicute<T>(CustomRequest<T> request);
    public abstract ISender GetSender();
}

