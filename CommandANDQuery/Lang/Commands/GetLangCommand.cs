using Models;
using System.Globalization;

namespace CommandANDQuery.Games.Commands;

public sealed record GetLangCommand() : IRequest<CultureInfo>;
