using BaseUtils.FlowControl.ErrorType;
using BaseUtils.FlowControl.ResultType;
using BaseValueObjects.ValueObjects;

namespace BaseValueObjects.Builder;
public static class ValueObjectBuilder<VO, T> 
where VO: IValueObject<T, VO>
{
    public const string NullValueErrorMessage = "Value object cannot received null value.";
    public static Result<VO> Build(T value)
    {
        if (value is null)
            return ErrorResponse.InvalidTypeError(NullValueErrorMessage);

        VO valueObject = VO.Create(value);
        
        var validator = valueObject.ApplyValidation();
        if (!validator.IsValid())
            return validator.Errors;
        
        return Result<VO>.Success(valueObject);
    }
}