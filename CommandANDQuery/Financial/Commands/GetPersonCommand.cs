using Models;
using Share;

namespace CommandANDQuery.Financial.Commands;

public sealed record GetPersonCommand() : IRequest<CustomResponse<List<Person>>>;
