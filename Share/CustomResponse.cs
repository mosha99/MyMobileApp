using CommandANDQuery;
using FluentValidation.Results;

namespace Share;



public class CustomResponse<T> : CustomResponse
{
    public T Result { get; set; }
    public CustomResponse<T> SetResult(T result)
    {
        ResponseType = ResponseType.Success;

        Result = result;

        return this;
    }

}

public class CustomResponse
{
    public Dictionary<string, IEnumerable<string>> ValidationErrors { get; set; }
    public ResponseType ResponseType { get; set; }
    public MessageInfo? MessageInfo { get; set; }
    public CustomResponse Success()
    {
        ResponseType = ResponseType.Success;
        return this;
    }
    public CustomResponse SetError()
    {
        ResponseType = ResponseType.Error;
        return this;
    }
    public CustomResponse SetError(IEnumerable<List<ValidationFailure>> validations)
    {
        ResponseType = ResponseType.InvalidModel;

        ValidationErrors = new Dictionary<string, IEnumerable<string>>();

        var GrupedErrors = validations
            .Single()
            .Select(x => new { x.PropertyName, x.ErrorMessage })
            .Distinct()
            .GroupBy(x => x.PropertyName);

        foreach (var item in GrupedErrors)
        {
            ValidationErrors.Add(item.Key, item.Select(x => x.ErrorMessage));
        }

        return this;
    }

    public CustomResponse SetMessage(MessageInfo messageInfo)
    {
        MessageInfo = messageInfo;
        return this;
    }
}


//public interface ICustomResponse
//{
//    Dictionary<string, IEnumerable<string>> ValidationErrors { get; set; }
//    ResponseType ResponseType { get; set; }
//    ICustomResponse Success();
//    ICustomResponse SetError(IEnumerable<List<ValidationFailure>> validations);
//}

//public interface ICustomResponse<T> : ICustomResponse
//{
//    ICustomResponse<T> SetResult(T result);
//}




public enum ResponseType
{
    Success,
    Error,
    InvalidModel,
}
