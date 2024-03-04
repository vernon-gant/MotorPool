namespace MotorPool.Services.Utils;

public class PagedViewModel<T> where T : class
{

    public required int PagesAfter { get; init; }

    public required IList<T> Elements { get; init; }

}