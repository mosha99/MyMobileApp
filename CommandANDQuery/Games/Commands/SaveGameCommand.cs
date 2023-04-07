using Models;


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
