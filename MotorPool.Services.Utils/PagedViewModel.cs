using MotorPool.Utils.Exceptions;

namespace MotorPool.Services.Utils;

public class PagedViewModel<T> where T : class
{

    public int LastPage { get; private set; }

    public IList<T> Elements { get; private set; }

    public static PagedViewModel<T> FromOptionsAndElements(PageOptions pageOptions, IList<T> elements, int allElementsCount)
    {
        int lastPossiblePage = pageOptions.LastPage(allElementsCount);

        if (elements.Count == 0 && pageOptions.PageNumber > 1) throw new ExceededPageLimitException(pageOptions.PageNumber, lastPossiblePage);

        return new PagedViewModel<T>
        {
            LastPage = lastPossiblePage,
            Elements = elements
        };
    }

}