using CommandANDQuery;
using Resources;


namespace Share.Messages;

public class DeleteCompletMessage : MessageInfo
{
    public DeleteCompletMessage() : base(MessageType.Sucsses, 5)
    {
    }

    public override string GetMessage() => LangResource.Deleted;
}

public class DeleteGameQuestionMessage : MessageInfo
{
    string Name { get; set; }
    public DeleteGameQuestionMessage(string name) : base(MessageType.Question, 10)
    {
        Name = name;
    }

    public override string GetMessage() => string.Format(LangResource.GameDeleteQuestion,Name);
}
public class DeleteGameMemberQuestionMessage : MessageInfo
{
    string Name { get; set; }
    public DeleteGameMemberQuestionMessage(string name) : base(MessageType.Question, 10)
    {
        Name = name;
    }

    public override string GetMessage() => string.Format(LangResource.GameMemberDeleteQuestion,Name);
}
public class DeletePersonQuestionMessage : MessageInfo
{
    string Name { get; set; }
    public DeletePersonQuestionMessage(string name) : base(MessageType.Question, 10)
    {
        Name = name;
    }

    public override string GetMessage() => string.Format(LangResource.GamePersonDeleteQuestion, Name);
}