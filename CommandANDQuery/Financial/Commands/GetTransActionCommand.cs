using Models;
using Share;

namespace CommandANDQuery.Financial.Commands;

public sealed record GetTranCActionCommand(int PersonId) : IRequest<CustomResponse<List<TranCAction>>>;
