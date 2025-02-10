using BaseUtils.FlowControl.ErrorType;
using BaseValueObjects.Tests.MockedValueObjects;
using BaseValueObjects.Validators.Extensions;

namespace BaseValueObjects.Tests.ValueObjects;

public class SimpleValueObjectTests
{
    [Fact(DisplayName = "VO-SIMPLE-1.01: Create simple value object.")]
    public void ValueObjectTest1()
    {
        // Given
        var mockedString = "valid string";
    
        // When
        var valueObjectResult = MockedValueObject.Build(mockedString);
    
        // Then
        Assert.True(valueObjectResult.IsSuccess);
        Assert.Equal(mockedString, valueObjectResult.GetValue().Value);
    }

    [Fact(DisplayName = "VO-SIMPLE-1.02: Create simple value object with invalid value.")]
    public void ValueObjectTest2()
    {
        // Given
        var mockedString = "velid string";
    
        // When
        var valueObjectResult = MockedValueObject.Build(mockedString);
    
        // Then
        Assert.True(valueObjectResult.IsFailure);
        Assert.Single(valueObjectResult.Errors);
        Assert.Equal(
            StringValidatorExtensions.SetNotContainCharErrorMessage
            .Replace(ErrorResponse.ReferenceToVariable, "a"), 
                valueObjectResult.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "VO-SIMPLE-1.03: Create simple value object with null value.")]
    public void ValueObjectTest3()
    {
        // When
        #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        var valueObjectResult = MockedValueObject.Build(null);
        #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        // Then
        Assert.True(valueObjectResult.IsFailure);
        Assert.Single(valueObjectResult.Errors);
        Assert.Equal(MockedValueObject.NullValueErrorMessage, 
                     valueObjectResult.Errors[0].ErrorMessage());
    }
}
