using AutoFixture;
using BaseUtils.FlowControl.ErrorType;
using BaseValueObjects.Validators;

namespace BaseValueObjects.Tests.Validators;

public class ValueValidatorTests
{
    [Theory(DisplayName = "TVV-1.01: Create value Validator with any primitive types.")]
    [InlineData("string")]
    [InlineData(1)]
    [InlineData(2.3)]
    [InlineData((float)3.1)]
    [InlineData(true)]
    public void CreateValueValidatorWithManyTypes<T>(T value)
    {
        // Act
        var validator = new ValueValidator<T>(value);

        // Assert
        Assert.Equal(value, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "TVV-2.01: Add error to validator.")]
    public void AddErrorToValidator()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<int>();

        var validator = new ValueValidator<int>(value);

        var messageError = fixture.Create<string>();
        var error = ErrorResponse.InvalidTypeError(messageError);
    
        // When
        validator.AddError(error);

        // Then
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(messageError, validator.Errors[0].ErrorMessage());

    }

    [Fact(DisplayName = "TVV-2.02: Add multiple errors to validator.")]
    public void AddErrorsToValidator()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<int>();

        var validator = new ValueValidator<int>(value);

        var messageError1 = fixture.Create<string>();
        var error1 = ErrorResponse.InvalidTypeError(messageError1);

        var messageError2 = fixture.Create<string>();
        var error2 = ErrorResponse.InvalidTypeError(messageError2);
    
        // When
        validator.AddError(error1);
        validator.AddError(error2);

        // Then
        Assert.False(validator.IsValid());
        Assert.Equal(2, validator.Errors.Count);

        Assert.Equal(messageError1, validator.Errors[0].ErrorMessage());
        Assert.Equal(messageError2, validator.Errors[1].ErrorMessage());
    }

    [Fact(DisplayName = "TVV-2.03: Add multiple errors to validator.")]
    public void AddSameErrorsToValidator()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<int>();

        var validator = new ValueValidator<int>(value);

        var messageError1 = fixture.Create<string>();
        var error1 = ErrorResponse.InvalidTypeError(messageError1);
    
        // When
        validator.AddError(error1);
        validator.AddError(error1);

        // Then
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);

        Assert.Equal(messageError1, validator.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "TVV-2.04: Add null error to validator.")]
    public void AddnullErrorToValidator()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<int>();

        var validator = new ValueValidator<int>(value);
    
        // When
        validator.AddError(error: null);

        // Then
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);

        Assert.Equal(ErrorResponse.InvalidTypeDefaultMessage, validator.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "TVV-3.01: Add message error to validator.")]
    public void AddErrorMessageToValidator()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<int>();

        var validator = new ValueValidator<int>(value);

        var messageError = fixture.Create<string>();
    
        // When
        validator.AddError(messageError);

        // Then
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(messageError, validator.Errors[0].ErrorMessage());

    }

    [Fact(DisplayName = "TVV-3.02: Add multiple message errors to validator.")]
    public void AddMessagesErrorToValidator()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<int>();

        var validator = new ValueValidator<int>(value);

        var messageError1 = fixture.Create<string>();

        var messageError2 = fixture.Create<string>();
    
        // When
        validator.AddError(messageError1);
        validator.AddError(messageError2);

        // Then
        Assert.False(validator.IsValid());
        Assert.Equal(2, validator.Errors.Count);

        Assert.Equal(messageError1, validator.Errors[0].ErrorMessage());
        Assert.Equal(messageError2, validator.Errors[1].ErrorMessage());
    }

    [Fact(DisplayName = "TVV-3.03: Add null message error to validator.")]
    public void AddNullMessageErrorsToValidator()
    {
        // Given
        Fixture fixture = new();
        var value = fixture.Create<int>();

        var validator = new ValueValidator<int>(value);
    
        // When
        validator.AddError(messageError: null);

        // Then
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);

        Assert.Equal(ErrorResponse.InvalidTypeDefaultMessage, validator.Errors[0].ErrorMessage());
    }
}
