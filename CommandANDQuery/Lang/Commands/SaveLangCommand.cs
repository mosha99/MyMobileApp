using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandANDQuery.Games.Commands
{
    public record SaveLangCommand (string culture) : IRequest;
}
