using BaseUtils.FlowControl.ErrorType;

namespace BaseValueObjects.Validators;
public class ValueValidator<T>(T value) : IValueValidator<T>
{

    public T Value { get; private set; } = value;
    public List<ErrorResponse> Errors {get; private set;} = [];
    public bool IsValid() => Errors.Count == 0;

    public void AddError(string messageError)
    => Errors.Add(ErrorResponse.InvalidTypeError(messageError));
    
    public void AddError(ErrorResponse error)
    {
        if (error is null) 
            Errors.Add(ErrorResponse.InvalidTypeError());
        else if (!Errors.Any(err => err.ErrorId == error.ErrorId))
            Errors.Add(error);
    }
}
