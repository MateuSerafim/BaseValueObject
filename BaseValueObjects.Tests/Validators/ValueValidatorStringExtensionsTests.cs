using BaseUtils.FlowControl.ErrorType;
using BaseValueObjects.Validators;
using BaseValueObjects.Validators.Extensions;

namespace BaseValueObjects.Tests.Validators;
public class ValueValidatorStringExtensionsTests
{

    [Fact(DisplayName = "VVST-1.01: text with min value is validated.")]
    public void ValidatorSetMinLengthTextTest1()
    {
        // Given
        Random random = new();
        int number = random.Next(1, 50);

        string mockedText = new ('a', number);
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText).SetMinLengthText((uint)number);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "VVST-1.02: text bigger then min value is validated.")]
    public void ValidatorSetMinLengthTextTest2()
    {
        // Given
        Random random = new();
        int number = random.Next(1, 50);

        string mockedText = new ('a', number + 1);
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText).SetMinLengthText((uint)number);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "VVST-1.03: text minor then min value is invalidated.")]
    public void ValidatorSetMinLengthTextTest3()
    {
        // Given
        Random random = new();
        int number = random.Next(2, 50);

        string mockedText = new ('a', number - 1);
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText).SetMinLengthText((uint)number);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(
            StringValidatorExtensions.MinLengthErrorMessage.
            Replace(ErrorResponse.ReferenceToVariable, number.ToString()), 
            validator.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "VVST-2.01: text with max value is validated.")]
    public void ValidatorSetMaxLengthTextTest1()
    {
        // Given
        Random random = new();
        int number = random.Next(1, 50);

        string mockedText = new ('a', number);
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText).SetMaxLengthText((uint)number);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "VVST-2.02: text minor then max value is validated.")]
    public void ValidatorSetMaxLengthTextTest2()
    {
        // Given
        Random random = new();
        int number = random.Next(1, 50);

        string mockedText = new ('a', number - 1);
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText).SetMaxLengthText((uint)number);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "VVST-2.03: text major then max value is invalidated.")]
    public void ValidatorSetMaxLengthTextTest3()
    {
        // Given
        Random random = new();
        int number = random.Next(2, 50);

        string mockedText = new ('a', number + 1);
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText).SetMaxLengthText((uint)number);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(
            StringValidatorExtensions.MaxLengthErrorMessage.
            Replace(ErrorResponse.ReferenceToVariable, number.ToString()), 
            validator.Errors[0].ErrorMessage());
    }
}
