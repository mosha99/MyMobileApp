using Share;

namespace CommandANDQuery.Financial.Commands;

public sealed record EditPersonCommand(string Name, int id): IRequest<CustomResponse>;
