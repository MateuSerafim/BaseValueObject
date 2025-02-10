using BaseUtils.FlowControl.ErrorType;
using BaseUtils.FlowControl.ResultType;

namespace BaseValueObjects.ValueObjects.SimpleValueObject;
public abstract class ValueObject<T>(T value)
{
    public T Value { get; private set; } = value;

    public const string NullValueErrorMessage = "Value object cannot received null value.";

    protected static Result<VO> Build<VO>(VO valueObject)
    where VO : IValueObject<T, VO>
    {
        if (valueObject.Value is null)
            return ErrorResponse.InvalidTypeError(NullValueErrorMessage);
        
        var validator = valueObject.Validator();
        if (!validator.IsValid())
            return validator.Errors;
        
        return valueObject;
    }
}
