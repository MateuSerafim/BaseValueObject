namespace BaseValueObjects.Validators.Extensions;
public static class RegexCommonExpressions
{
    public const string GenericEmail = @"^[\w\.\-]+@[\w\.-]+\.+\w+";
    public const string BrazilCPF = @"^\d{3}\.\d{3}.\d{3}\-\d{2}|^d{11}";
}
