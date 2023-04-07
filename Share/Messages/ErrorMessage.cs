using CommandANDQuery;
using Resources;

namespace Share.Messages
{
    public class ErrorMessage : MessageInfo
    { 
        string Message;
        public ErrorMessage(string message) : base(MessageType.Error, 10)
        {
            Message = message;
        }

        public override string GetMessage() => Message;
    }
}
