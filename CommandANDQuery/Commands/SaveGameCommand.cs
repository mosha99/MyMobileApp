using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandANDQuery.Commands
{
    public sealed record SaveGameCommand(Game Game) : IRequest<int>;
}
