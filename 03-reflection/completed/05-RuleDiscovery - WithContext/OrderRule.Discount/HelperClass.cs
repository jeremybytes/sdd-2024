namespace OrderRule.Discount;

public class HelperClass
{
    // This class is not actually used,
    // but it is here to show that it will
    // be ignored by the dynamic loader that
    // is looking for classes that implement
    // "IOrderRule"

    public string Message => "I am a helper class";
}
