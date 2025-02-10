using BaseUtils.FlowControl.ResultType;
using BaseValueObjects.Validators;
using BaseValueObjects.Validators.Extensions;
using BaseValueObjects.ValueObjects.SimpleValueObject;

namespace BaseValueObjects.Tests.MockedValueObjects;

public class MockedValueObject : ValueObject<string>, IValueObject<string, MockedValueObject>
{
    public const char MandatoryChar = 'a';
    public const int MinLength = 5;
    public const int MaxLength = 15;

    private MockedValueObject(string value) : base(value)
    {

    }

    public static Result<MockedValueObject> Build(string value) 
    => Build(new MockedValueObject(value));

    public IValueValidator<string> Validator()
    => new ValueValidator<string>(Value).SetContainsChar(MandatoryChar)
                                        .SetMinLengthText(MinLength)
                                        .SetMaxLengthText(MaxLength);
}
