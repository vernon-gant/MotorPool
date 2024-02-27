using System.ComponentModel.DataAnnotations;

namespace MotorPool.Utils.ValidationAttributes;

public class DateRangeAttribute : ValidationAttribute
{

    public required int MinYear { get; init; }

    public override bool IsValid(object? value)
    {
        if (value is not DateTime date) return false;

        return date.Year >= MinYear && date.Year <= DateTime.Now.Year;
    }

}