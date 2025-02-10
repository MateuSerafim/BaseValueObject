using BaseUtils.FlowControl.ResultType;
using BaseValueObjects.Validators;

namespace BaseValueObjects.ValueObjects.SimpleValueObject;
public interface IValueObject<T, VO> 
{
    T Value { get; }

    static abstract Result<VO> Build(T value);

    IValueValidator<T> Validator();
}
