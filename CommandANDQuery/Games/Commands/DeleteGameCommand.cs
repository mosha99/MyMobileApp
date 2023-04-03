using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandANDQuery.Games.Commands;

public class DeleteGameCommand : CustomRequest<bool>
{
    public Game Game { get; set; }
    public DeleteGameCommand(Game game)
    {
        Game = game;
    }
}
