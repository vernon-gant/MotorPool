using System.ComponentModel.DataAnnotations;

using MotorPool.Utils.ValidationAttributes;

namespace MotorPool.Services.Utils;

public class PageOptionsDTO
{

    [NonNegative(CanBeNull = true)]
    public int? PageNumber { get; set; }

    [NonNegative(CanBeNull = false)]
    public int? ElementsPerPage { get; set; }

    public static implicit operator PageOptions(PageOptionsDTO dto)
    {
        return new ()
        {
            PageNumber = dto.PageNumber ?? PageOptions.DEFAULT_PAGE_NUMBER,
            ElementsPerPage = dto.ElementsPerPage ?? PageOptions.DEFAULT_ELEMENTS_PER_PAGE
        };
    }

}

public class PageOptions
{

    public static readonly int DEFAULT_PAGE_NUMBER = 0;

    public static readonly int DEFAULT_ELEMENTS_PER_PAGE = 100;

    public required int PageNumber { get; set; }

    public required int ElementsPerPage { get; set; }

}