namespace MotorPool.Auth.Manager;

public class IsManagerAccessibleFilter : IEndpointFilter
{

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        throw new NotImplementedException();
    }

}