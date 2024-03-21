using System.ComponentModel.DataAnnotations;

public class NotOnWeekendAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        DateTime date = (DateTime)value;
        return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
    }
}