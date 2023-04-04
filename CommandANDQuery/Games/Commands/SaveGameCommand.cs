using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandANDQuery.Games.Commands
{
    public class SaveGameCommand : IRequest<int>
    {
        public Game Game { get; set; }
        public SaveGameCommand(Game game)
        {
            Game = game;
        }
    }
}
