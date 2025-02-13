using System;
using BaseUtils.FlowControl.ErrorType;
using BaseValueObjects.Validators;
using BaseValueObjects.Validators.Extensions;

namespace BaseValueObjects.Tests.Validators;
public class ValueValidatorIntegerExtensions
{
    [Fact(DisplayName = "VV-Int-T-1.01: integer with value major the min is validated.")]
    public void ValidatorSetMinIntegerLengthTest1()
    {
        // Given
        Random random = new();
        int number = random.Next(1, 50);

        int mockedLimit = number - 1;
    
        // When
        IValueValidator<int> validator = 
        new ValueValidator<int>(number).SetMinValue(mockedLimit);
    
        // Then
        Assert.Equal(number, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "VV-Int-T-1.02: integer with value equal the min is validated.")]
    public void ValidatorSetMinIntegerLengthTest2()
    {
        // Given
        Random random = new();
        int number = random.Next(1, 50);

        int mockedLimit = number;
    
        // When
        IValueValidator<int> validator = 
        new ValueValidator<int>(number).SetMinValue(mockedLimit);
    
        // Then
        Assert.Equal(number, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "VV-Int-T-1.03: integer with value minor the min is invalidated.")]
    public void ValidatorSetMinIntegerLengthTest3()
    {
        // Given
        Random random = new();
        int number = random.Next(1, 50);

        int mockedLimit = number + 1;
    
        // When
        IValueValidator<int> validator = 
        new ValueValidator<int>(number).SetMinValue(mockedLimit);
    
        // Then
        Assert.Equal(number, validator.Value);
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(
            IntegerValidatorExtensions.MinValueErrorMessage.
            Replace(ErrorResponse.ReferenceToVariable, mockedLimit.ToString()), 
            validator.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "VV-Int-T-2.01: integer with value minor to the max is validated.")]
    public void ValidatorSetMaxIntegerLengthTest1()
    {
        // Given
        Random random = new();
        int number = random.Next(1, 50);

        int mockedLimit = number + 1;
    
        // When
        IValueValidator<int> validator = 
        new ValueValidator<int>(number).SetMaxValue(mockedLimit);
    
        // Then
        Assert.Equal(number, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "VV-Int-T-2.02: integer with value equal the max is validated.")]
    public void ValidatorSetMaxIntegerLengthTest2()
    {
        // Given
        Random random = new();
        int number = random.Next(1, 50);

        int mockedLimit = number;
    
        // When
        IValueValidator<int> validator = 
        new ValueValidator<int>(number).SetMaxValue(mockedLimit);
    
        // Then
        Assert.Equal(number, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "VV-Int-T-2.03: integer with value major the max is invalidated.")]
    public void ValidatorSetMaxIntegerLengthTest3()
    {
        // Given
        Random random = new();
        int number = random.Next(1, 50);

        int mockedLimit = number - 1;
    
        // When
        IValueValidator<int> validator = 
        new ValueValidator<int>(number).SetMaxValue(mockedLimit);
    
        // Then
        Assert.Equal(number, validator.Value);
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(
            IntegerValidatorExtensions.MaxValueErrorMessage.
            Replace(ErrorResponse.ReferenceToVariable, mockedLimit.ToString()), 
            validator.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "VV-Int-T-3.01: integer positive is validated.")]
    public void ValidatorSetPositiveRuleTest1()
    {
        // Given
        Random random = new();
        int number = random.Next(1, 50);
    
        // When
        IValueValidator<int> validator = 
        new ValueValidator<int>(number).SetPositiveMandatory();
    
        // Then
        Assert.Equal(number, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "VV-Int-T-3.02: integer with value equal 0 is validated.")]
    public void ValidatorSetPositiveRuleTest2()
    {
        // Given
        int number = 0;
    
        // When
        IValueValidator<int> validator = 
        new ValueValidator<int>(number).SetPositiveMandatory();
    
        // Then
        Assert.Equal(number, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "VV-Int-T-3.03: integer with negative value is invalidated.")]
    public void ValidatorSetPositiveRuleTest3()
    {
        // Given
        Random random = new();
        int number = random.Next(-50, -1);
    
        // When
        IValueValidator<int> validator = 
        new ValueValidator<int>(number).SetPositiveMandatory();
    
        // Then
        Assert.Equal(number, validator.Value);
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(IntegerValidatorExtensions.NotPositiveErrorMessage, 
                     validator.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "VV-Int-T-4.01: integer negative is validated.")]
    public void ValidatorSetNegativeRuleTest1()
    {
        // Given
        Random random = new();
        int number = random.Next(-50, -1);
    
        // When
        IValueValidator<int> validator = 
        new ValueValidator<int>(number).SetNegativeMandatory();
    
        // Then
        Assert.Equal(number, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Fact(DisplayName = "VV-Int-T-4.02: integer with value equal 0 is invalidated.")]
    public void ValidatorSetNegativeRuleTest2()
    {
        // Given
        int number = 0;
    
        // When
        IValueValidator<int> validator = 
        new ValueValidator<int>(number).SetNegativeMandatory();
    
        // Then
        Assert.Equal(number, validator.Value);
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(IntegerValidatorExtensions.NotNegativeErrorMessage, 
                     validator.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "VV-Int-T-4.03: integer with negative value is invalidated.")]
    public void ValidatorSetNegativeRuleTest3()
    {
        // Given
        Random random = new();
        int number = random.Next(1, 50);
    
        // When
        IValueValidator<int> validator = 
        new ValueValidator<int>(number).SetNegativeMandatory();
    
        // Then
        Assert.Equal(number, validator.Value);
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(IntegerValidatorExtensions.NotNegativeErrorMessage, 
                     validator.Errors[0].ErrorMessage());
    }

    [Theory(DisplayName = "VV-Int-T-5.01: integer old is validated.")]
    [InlineData(-3)]
    [InlineData(-1)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    public void ValidatorSetOddRuleTest1(int number)
    {    
        // When
        IValueValidator<int> validator = 
        new ValueValidator<int>(number).SetOddMandatory();
    
        // Then
        Assert.Equal(number, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Theory(DisplayName = "VV-Int-T-5.02: integer even is invalidated.")]
    [InlineData(-4)]
    [InlineData(-2)]
    [InlineData(0)]
    [InlineData(2)]
    [InlineData(4)]
    public void ValidatorSetOddRuleTest2(int number)
    {    
        // When
        IValueValidator<int> validator = 
        new ValueValidator<int>(number).SetOddMandatory();
    
        // Then
        Assert.Equal(number, validator.Value);
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(IntegerValidatorExtensions.NotOddErrorMessage, 
                     validator.Errors[0].ErrorMessage());
    }

    [Theory(DisplayName = "VV-Int-T-6.01: integer even is validated.")]
    [InlineData(-4)]
    [InlineData(-2)]
    [InlineData(0)]
    [InlineData(2)]
    [InlineData(4)]
    public void ValidatorSetEvenRuleTest1(int number)
    {    
        // When
        IValueValidator<int> validator = 
        new ValueValidator<int>(number).SetEvenMandatory();
    
        // Then
        Assert.Equal(number, validator.Value);
        Assert.True(validator.IsValid());
        Assert.Empty(validator.Errors);
    }

    [Theory(DisplayName = "VV-Int-T-6.02: integer old is invalidated.")]
    [InlineData(-3)]
    [InlineData(-1)]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    public void ValidatorSetEvenRuleTest2(int number)
    {    
        // When
        IValueValidator<int> validator = 
        new ValueValidator<int>(number).SetEvenMandatory();
    
        // Then
        Assert.Equal(number, validator.Value);
        Assert.False(validator.IsValid());
        Assert.Single(validator.Errors);
        Assert.Equal(IntegerValidatorExtensions.NotOddErrorMessage, 
                     validator.Errors[0].ErrorMessage());
    }
}
