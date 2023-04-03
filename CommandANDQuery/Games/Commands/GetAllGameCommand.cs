global using MediatR;
using Models;

namespace CommandANDQuery.Games.Commands;

public sealed record GetGamesCommand() : IRequest<List<Game>>;
