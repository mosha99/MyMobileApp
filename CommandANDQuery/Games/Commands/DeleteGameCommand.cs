using Models;


namespace CommandANDQuery.Games.Commands;

public class DeleteGameCommand : IRequest<bool>
{
    public Game Game { get; set; }
    public DeleteGameCommand(Game game)
    {
        Game = game;
    }
}
