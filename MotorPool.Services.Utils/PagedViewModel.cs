﻿using MotorPool.Utils.Exceptions;

namespace MotorPool.Services.Utils;

public class PagedViewModel<T> where T : class
{

    public int TotalPages { get; private set; }

    public IList<T> Elements { get; private set; }

    public static PagedViewModel<T> FromOptionsAndElements(PageOptions pageOptions, IList<T> elements, int allElementsCount)
    {
        int lastPossiblePage = pageOptions.TotalPages(allElementsCount);

        if (elements.Count == 0 && pageOptions.PageNumber > 1) throw new ExceededPageLimitException(pageOptions.PageNumber, lastPossiblePage);

        return new PagedViewModel<T>
        {
            TotalPages = lastPossiblePage,
            Elements = elements
        };
    }

}