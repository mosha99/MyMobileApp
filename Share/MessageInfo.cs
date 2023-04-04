using Share;

namespace CommandANDQuery;

public abstract class MessageInfo
{

    public int Counter { get; set; }
    public string Body => GetMessage();
    public MessageType Type { get; set; }

    public MessageInfo(MessageType type, int counter = 5)
    {
        Type = type;
        Counter = counter;
    }

    public abstract string GetMessage();
    public async Task<bool> Show() => await MessageManager.ShowMessage(this);
}
