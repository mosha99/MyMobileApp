using CommandANDQuery;

namespace Share
{
    public interface IMyPage
    {
        void StateHasChanged();
        Task InvokeAsync(Action action);
    }

    public static class MessageManager
    {
        static object monitor = new object();
        public static int counter = 20;
        public static bool? MessageResult = null;
        public static bool showMessage = false;
        public static MessageInfo messageInfo;
        public static IMyPage mainLayout;

        public static void MessageResponse(bool response)
        {
            MessageResult = response;
            HideMessage();
        }
        public static void HideMessage()
        {
            mainLayout.InvokeAsync(() =>
            {
                showMessage = false;
                mainLayout.StateHasChanged();
            });
        }
        public static async Task<bool> ShowMessage(MessageInfo massageInfo)
        {
            Monitor.Enter(monitor);

            try
            {
                await mainLayout.InvokeAsync(() =>
                 {
                     messageInfo = massageInfo;

                     showMessage = true;

                     counter = massageInfo.Counter;

                     mainLayout.StateHasChanged();

                 });


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
        public static bool Getesult()
        {
            for (; counter >= 1; counter--)
            {
                if (MessageResult.HasValue)
                    return MessageResult.Value;

                Thread.Sleep(TimeSpan.FromSeconds(1));

                mainLayout.InvokeAsync(() =>
                {
                    mainLayout.StateHasChanged();
                });
            }
            return false;
        }
    }
}
