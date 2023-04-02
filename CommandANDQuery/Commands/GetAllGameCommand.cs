global using MediatR;
using Models;

namespace CommandANDQuery.Commands;

public sealed record GetGamesCommand() : IRequest<List<Game>>;
