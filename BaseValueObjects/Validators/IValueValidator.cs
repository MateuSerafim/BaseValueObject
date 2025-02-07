using BaseUtils.FlowControl.ErrorType;

namespace BaseValueObjects.Validators;

public interface IValueValidator<T>
{
    T Value {get; }
    List<ErrorResponse> Errors {get; }
    bool IsValid();
    void AddError(string messageError);
    void AddError(ErrorResponse error);
}