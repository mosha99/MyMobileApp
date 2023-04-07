using FluentValidation;
using FluentValidation.Results;
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
        try
        {
            var context = new ValidationContext<TRequest>(request);

            List<List<ValidationFailure>> Errors = new List<List<ValidationFailure>>();

            foreach (var item in _validators)
            {   
                ValidationResult result = await item.ValidateAsync(context);

                if(result != null)
                    Errors.Add(result.Errors);
            }


            if (Errors is not null && Errors.Any(x => x.Any()))
            {
                return GetResponse(new CustomResponse().SetError(Errors));
            }
            else
            {
                try
                {
                    TResponse response = await next();

                    if (response.MessageInfo is not null)
                        response.MessageInfo.Show();

                    return response;
                }
                catch (Exception ex)
                {
                    new ErrorMessage(ex.Message).Show();

                    return GetResponse(new CustomResponse().SetError());

                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    TResponse GetResponse(CustomResponse response)
    {
        if(response is TResponse res)
        {
            return res;
        }

        throw new Exception();
    }
}
