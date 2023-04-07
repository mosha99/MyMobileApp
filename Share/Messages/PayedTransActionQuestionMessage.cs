using CommandANDQuery;
using Resources;


namespace Share.Messages
{
    public class PayedTranCActionQuestionMessage : MessageInfo
    {
        public PayedTranCActionQuestionMessage(string name, decimal amount) : base(MessageType.Question, 15)
        {
            Name = name;
            Amount = amount;
        }

        string Name;
        decimal Amount;

        public override string GetMessage() => string.Format( LangResource.PayedTranCActionQuestionMessage,Amount,Name);
    }
}
