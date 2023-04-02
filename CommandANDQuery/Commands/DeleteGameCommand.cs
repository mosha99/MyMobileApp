using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandANDQuery.Commands;

public sealed record DeleteGameCommand(Game Game ) : IRequest<bool>;

