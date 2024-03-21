using System.ComponentModel.DataAnnotations;

public class FutureDateAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        DateTime date = (DateTime)value;
        return date >= DateTime.Now;
    }
}