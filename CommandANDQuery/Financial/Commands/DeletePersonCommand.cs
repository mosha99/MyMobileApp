using Share;

namespace CommandANDQuery.Financial.Commands;

public sealed record DeletePersonCommand(int id): IRequest<CustomResponse>;
