using MotorPool.Utils.ValidationAttributes;

namespace MotorPool.Services.Utils;

public class PageOptionsDTO
{

    [NonNegative(CanBeZero = false)]
    public int? PageNumber { get; set; }

    [NonNegative(CanBeZero = false)]
    public int? ElementsPerPage { get; set; }

    public static implicit operator PageOptions(PageOptionsDTO dto)
    {
        return new ()
        {
            PageNumber = dto.PageNumber ?? PageOptions.DEFAULT_PAGE_NUMBER,
            ElementsPerPage = dto.ElementsPerPage ?? PageOptions.DEFAULT_ELEMENTS_PER_PAGE_AMOUNT
        };
    }

}

public class PageOptions
{

    public static readonly int DEFAULT_PAGE_NUMBER = 1;

    public static readonly int DEFAULT_ELEMENTS_PER_PAGE_AMOUNT = 100;

    public required int PageNumber { get; set; }

    public required int ElementsPerPage { get; set; }

    public int LastPage(int entitiesCount) => entitiesCount / ElementsPerPage;

}