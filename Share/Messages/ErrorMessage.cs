using CommandANDQuery;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
