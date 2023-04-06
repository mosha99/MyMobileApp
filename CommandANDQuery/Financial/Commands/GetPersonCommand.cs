using Models;
using Share;

namespace CommandANDQuery.Financial.Commands;

public sealed record GetPersonCommand(int id) : IRequest<CustomResponse<Person>>;
public sealed record GetPepoleCommand() : IRequest<CustomResponse<List<Person>>>;
