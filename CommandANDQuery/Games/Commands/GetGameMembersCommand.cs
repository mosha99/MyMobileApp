using Models;

namespace CommandANDQuery.Games.Commands;

public sealed record GetGameMembersCommand(int GameId) : IRequest<List<GameMember>>;
