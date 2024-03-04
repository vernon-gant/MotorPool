namespace MotorPool.Utils.Exceptions;

public class ExceededPageLimitException(int pageNumber, int lastPage) : Exception($"Page number {pageNumber} exceeds the last page number {lastPage}.") { }