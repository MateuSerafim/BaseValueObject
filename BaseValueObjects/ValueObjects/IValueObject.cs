using BaseValueObjects.Validators;

namespace BaseValueObjects.ValueObjects;
public interface IValueObject<T, VO> 
{
    T Value { get; }

    static abstract VO Create(T value);

    IValueValidator<T> ApplyValidation();
}
