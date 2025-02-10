using AutoFixture;
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

    [Fact(DisplayName = "VVST-3.01: text with fixed value is validated.")]
    public void ValidatorSetLengthTextTest1()
    {
        // Given
        Random random = new();
        int number = random.Next(1, 50);

        string mockedText = new ('a', number);
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText).SetLengthText((uint)number);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "VVST-3.02: text with minor text lenght is invalidated.")]
    public void ValidatorSetLengthTextTest2()
    {
        // Given
        Random random = new();
        int number = random.Next(1, 50);

        string mockedText = new ('a', number - 1);
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText).SetLengthText((uint)number);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(
            StringValidatorExtensions.SetLengthErrorMessage.
            Replace(ErrorResponse.ReferenceToVariable, number.ToString()), 
            validator.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "VVST-3.03: text with major text lenght is invalidated.")]
    public void ValidatorSetLengthTextTest3()
    {
        // Given
        Random random = new();
        int number = random.Next(1, 50);

        string mockedText = new ('a', number + 1);
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText).SetLengthText((uint)number);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(
            StringValidatorExtensions.SetLengthErrorMessage.
            Replace(ErrorResponse.ReferenceToVariable, number.ToString()), 
            validator.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "VVST-4.01: text with char is validated.")]
    public void ValidatorSetHasCharTextTest1()
    {
        // Given
        Fixture fixture = new();
        var charCheck = fixture.Create<char>();

        string mockedText = new (charCheck, 5);
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText).SetContainsChar(charCheck);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "VVST-4.02: text without char is invalidated.")]
    public void ValidatorSetHasCharTextTest2()
    {
        // Given
        var charCheck = 'b';

        string mockedText = new ('a', 4);
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText).SetContainsChar(charCheck);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(
            StringValidatorExtensions.SetNotContainCharErrorMessage.
            Replace(ErrorResponse.ReferenceToVariable, charCheck.ToString()), 
            validator.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "VVST-5.01: text without char is validated.")]
    public void ValidatorSetHasNoCharTextTest1()
    {
        // Given
        var charCheck = 'b';
        string mockedText = new ('a', 4);
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText).SetNotContainsChar(charCheck);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "VVST-5.02: text without char is invalidated.")]
    public void ValidatorSetHasNoCharTextTest2()
    {
        // Given
        Fixture fixture = new();
        var charCheck = fixture.Create<char>();

        string mockedText = new (charCheck, 5);
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText).SetNotContainsChar(charCheck);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(
            StringValidatorExtensions.SetContainInvalidCharErrorMessage.
            Replace(ErrorResponse.ReferenceToVariable, charCheck.ToString()), 
            validator.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "VVST-6.01: text with corrected substring is validated.")]
    public void ValidatorSetSubstringValidationTest1()
    {
        // Given
        var subStringCheck = "mocked";
        string mockedText = "this a mocked text.";
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText).SetContainsSubstring(subStringCheck);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "VVST-6.02: text without substring is invalidated.")]
    public void ValidatorSetSubstringValidationTest2()
    {
        // Given
        var subStringCheck = "mocked";
        string mockedText = "this a invalid text.";
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText).SetContainsSubstring(subStringCheck);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(
            StringValidatorExtensions.NotContainSubstringErrorMessage.
            Replace(ErrorResponse.ReferenceToVariable, subStringCheck), 
            validator.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "VVST-7.01: text without incorrected substring is validated.")]
    public void ValidatorSetNotSubstringValidationTest1()
    {
        // Given
        var subStringCheck = "mocked";
        string mockedText = "this a aceptable text.";
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText).SetNotContainsSubstring(subStringCheck);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "VVST-7.02: text wit invalid substring is invalidated.")]
    public void ValidatorSetNotSubstringValidationTest2()
    {
        // Given
        var subStringCheck = "mocked";
        string mockedText = "this a invalid text wih mocked value.";
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText).SetNotContainsSubstring(subStringCheck);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(
            StringValidatorExtensions.NotContainSubstringErrorMessage.
            Replace(ErrorResponse.ReferenceToVariable, subStringCheck), 
            validator.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "VVST-8.01: text with correct regex is validated.")]
    public void ValidatorSetRegexValidationTest1()
    {
        // Given
        string mockedText = "email@testprovider.com";
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText)
        .SetRegexValidation(RegexCommonExpressions.GenericEmail);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "VVST-8.02: text with incorrect regex is invalidated.")]
    public void ValidatorSetNotRegexValidationTest2()
    {
        // Given
        string mockedText = "invalid.email";
    
        // When
        IValueValidator<string> validator = 
        new ValueValidator<string>(mockedText)
        .SetRegexValidation(RegexCommonExpressions.GenericEmail);
    
        // Then
        Assert.Equal(mockedText, validator.Value);
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(
            StringValidatorExtensions.IsInvalidStringErrorMessage.
            Replace(ErrorResponse.ReferenceToVariable, 
                    RegexCommonExpressions.GenericEmail), 
            validator.Errors[0].ErrorMessage());
    }
}