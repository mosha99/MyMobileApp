using Share;

namespace CommandANDQuery.Financial.Commands;

public sealed record AddPersonCommand(string Name) : IRequest<CustomResponse>;

