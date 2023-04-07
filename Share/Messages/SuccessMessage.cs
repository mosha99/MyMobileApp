using CommandANDQuery;
using Resources;

namespace Share.Messages
{
    public class SuccessMessage : MessageInfo
    {
        public SuccessMessage() : base(MessageType.Sucsses, 5)
        {
        }

        public override string GetMessage() => LangResource.Success;
    }
}
