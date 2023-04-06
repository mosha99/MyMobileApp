using FluentValidation;
using Share;
using Share.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CommandANDQuery.Financial.Validators;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : CustomResponse
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var Errors = _validators.Select(x => x.Validate(context).Errors);


        if (Errors.Any(x => x.Any()))
        {
            return new CustomResponse().SetError(Errors) as TResponse;
        }
        else
        {
            try
            {
                TResponse response = await next();
                return response;
            }
            catch (Exception ex)
            {
                new ErrorMessage(ex.Message).Show();

                return new CustomResponse().SetError()as TResponse;

            }
        }

    }

}
