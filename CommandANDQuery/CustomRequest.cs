using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandANDQuery;

public abstract class CustomRequest<T> : IRequest<T>
{
   public Func<MessageInfo,Task<bool>> ShowMessage { get; set; }
}
