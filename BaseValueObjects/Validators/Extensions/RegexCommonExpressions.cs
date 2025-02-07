namespace BaseValueObjects.Validators.Extensions;
public static class RegexCommonExpressions
{
    public static string GenericEmail => @"^[\w\.\-]+@[\w\.-]+\.+\w+";

    public static string BrazilCPF => @"^\d{3}\.\d{3}.\d{3}\-\d{2}|^d{11}";
}
