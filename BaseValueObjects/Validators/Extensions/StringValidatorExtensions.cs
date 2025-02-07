using System.Text.RegularExpressions;
using BaseUtils.FlowControl.ErrorType;

namespace BaseValueObjects.Validators.Extensions;
public static class StringValidatorExtensions
{
    public const string MinLengthErrorMessage = 
    $"Text need minimal length: {ErrorResponse.ReferenceToVariable}.";
    public static IValueValidator<string> SetMinLengthText(
        this IValueValidator<string> validator, 
        uint minLength,
        string errorMessage = MinLengthErrorMessage)
    {
        if (validator.Value.Length < minLength)
            validator.AddError(ErrorResponse.InvalidTypeError(errorMessage, minLength));
        return validator;
    }

    public const string MaxLengthErrorMessage = 
    $"Text need maximus length: {ErrorResponse.ReferenceToVariable}.";
    public static IValueValidator<string> SetMaxLengthText(
        this IValueValidator<string> validator, 
        uint maxLength,
        string errorMessage = MaxLengthErrorMessage)
    {
        if (validator.Value.Length > maxLength)
            validator.AddError(ErrorResponse.InvalidTypeError(errorMessage, maxLength));
        return validator;
    }

    public const string SetLengthErrorMessage = 
    $"Text need a fixed length: {ErrorResponse.ReferenceToVariable}.";
    public static IValueValidator<string> SetLengthText(
        this IValueValidator<string> validator, 
        uint exactLength,
        string errorMessage = SetLengthErrorMessage)
    {
        if (validator.Value.Length != exactLength)
            validator.AddError(ErrorResponse.InvalidTypeError(errorMessage, exactLength));
        return validator;
    }

    public const string SetNotContainCharErrorMessage = 
    $"Text need mandatory char: {ErrorResponse.ReferenceToVariable}.";
    public static IValueValidator<string> SetContainsChar(
        this IValueValidator<string> validator, 
        char neededChar,
        string errorMessage = SetNotContainCharErrorMessage)
    {
        if (!validator.Value.Contains(neededChar))
            validator.AddError(ErrorResponse.InvalidTypeError(errorMessage, neededChar));

        return validator;
    }

    public const string SetContainInvalidCharErrorMessage = 
    $"Text cannot has mandatory char: {ErrorResponse.ReferenceToVariable}.";
    public static IValueValidator<string> SetNotContainsChar(
        this IValueValidator<string> validator, 
        char verifyChar,
        string errorMessage = SetContainInvalidCharErrorMessage)
    {
        if (!validator.Value.Contains(verifyChar))
            validator.AddError(ErrorResponse.InvalidTypeError(errorMessage, verifyChar));

        return validator;
    }

    public const string NotContainSubstringErrorMessage = 
    $"Text need mandatory substring: {ErrorResponse.ReferenceToVariable}.";
    public static IValueValidator<string> SetContainsSubstring(
        this IValueValidator<string> validator, 
        string neededSubstring,
        string errorMessage = NotContainSubstringErrorMessage)
    {
        if (!validator.Value.Contains(neededSubstring))
            validator.AddError(ErrorResponse.InvalidTypeError(errorMessage, neededSubstring));

        return validator;
    }

    public const string ContainInvalidSubstringErrorMessage = 
    $"Invalid text type: {ErrorResponse.ReferenceToVariable}.";
    public static IValueValidator<string> SetRegexValidation(
        this IValueValidator<string> validator, 
        string regexPattern,
        string errorMessage = SetNotContainCharErrorMessage)
    {
        if (!Regex.IsMatch(validator.Value, regexPattern))
            validator.AddError(ErrorResponse.InvalidTypeError(errorMessage, regexPattern));

        return validator;
    }
}
