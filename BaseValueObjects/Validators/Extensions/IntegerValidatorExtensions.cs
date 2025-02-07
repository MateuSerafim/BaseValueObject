using BaseUtils.FlowControl.ErrorType;

namespace BaseValueObjects.Validators.Extensions;

public static class IntegerValidatorExtensions
{
    public const string MinValueErrorMessage = 
    $"The minimal value is: {ErrorResponse.ReferenceToVariable}.";
    public static IValueValidator<int> SetMinValue(this IValueValidator<int> validator, 
    int minValue, string errorMessage = MinValueErrorMessage)
    {
        if (validator.Value < minValue)
            validator.AddError(ErrorResponse.InvalidTypeError(errorMessage, minValue));
        return validator;
    }

    public const string MaxValueErrorMessage = 
    $"The maximus value is: {ErrorResponse.ReferenceToVariable}.";
    public static IValueValidator<int> SetMaxValue(this IValueValidator<int> validator, 
    int maxValue, string errorMessage = MaxValueErrorMessage)
    {
        if (validator.Value > maxValue)
            validator.AddError(ErrorResponse.InvalidTypeError(errorMessage, maxValue));
        return validator;
    }

    public const string NotPositiveErrorMessage = "The value need be positive.";
    public static IValueValidator<int> SetPositiveMandatory(this IValueValidator<int> validator, 
    string errorMessage = NotPositiveErrorMessage)
    {
        if (validator.Value < 0)
            validator.AddError(ErrorResponse.InvalidTypeError(errorMessage));
        return validator;
    }

    public const string NotNegativeErrorMessage = "The value need be negative.";
    public static IValueValidator<int> SetNegativeMandatory(this IValueValidator<int> validator, 
    string errorMessage = NotNegativeErrorMessage)
    {
        if (validator.Value >= 0)
            validator.AddError(ErrorResponse.InvalidTypeError(errorMessage));
        return validator;
    }
}
