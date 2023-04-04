using CommandANDQuery;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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