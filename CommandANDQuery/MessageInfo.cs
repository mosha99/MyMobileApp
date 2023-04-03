namespace CommandANDQuery;

public class MessageInfo
{

    public int Counter { get; set; }
    public string Body { get; set; }
    public MessageType Type { get; set; }

    public MessageInfo(MessageType type, string body, int counter = 5)
    {
        Type = type;
        Body = body;
        Counter = counter;
    }
}
