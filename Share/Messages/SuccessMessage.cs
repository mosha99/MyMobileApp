using CommandANDQuery;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
