using System.Security.Claims;

using MotorPool.API.EndpointFilters;
using MotorPool.Services.Enterprise.Exceptions;
using MotorPool.Services.Enterprise.Models;
using MotorPool.Services.Enterprise.Services;
using MotorPool.Services.Manager;

namespace MotorPool.API.Endpoints;

public static class EnterpriseEndpoints
{

    public static void MapEnterpriseEndpoints(this IEndpointRouteBuilder managerResourcesGroupBuilder)
    {
        RouteGroupBuilder enterprisesGroupBuilder = managerResourcesGroupBuilder.MapGroup("enterprises");

        enterprisesGroupBuilder.MapGet("", GetAll)
                               .WithName("GetAllEnterprises")
                               .Produces<List<EnterpriseViewModel>>();

        enterprisesGroupBuilder.MapGet("{enterpriseId:int}", GetById)
                               .AddEndpointFilter<EnterpriseExistsFilter>()
                               .AddEndpointFilter<IsManagerAccessibleEnterpriseFilter>()
                               .WithName("GetEnterpriseById")
                               .Produces<EnterpriseViewModel>()
                               .Produces(StatusCodes.Status404NotFound)
                               .Produces(StatusCodes.Status403Forbidden);

        enterprisesGroupBuilder.MapPost("", Create)
                               .WithParameterValidation()
                               .WithName("CreateEnterprise")
                               .Produces<EnterpriseViewModel>()
                               .Produces(StatusCodes.Status400BadRequest)
                               .Produces(StatusCodes.Status201Created);

        enterprisesGroupBuilder.MapPut("{enterpriseId:int}", Update)
                               .WithParameterValidation()
                               .AddEndpointFilter<EnterpriseExistsFilter>()
                               .AddEndpointFilter<IsManagerAccessibleEnterpriseFilter>()
                               .WithName("UpdateEnterprise")
                               .Produces(StatusCodes.Status400BadRequest)
                               .Produces(StatusCodes.Status204NoContent)
                               .Produces(StatusCodes.Status404NotFound)
                               .Produces(StatusCodes.Status403Forbidden);

        enterprisesGroupBuilder.MapDelete("{enterpriseId:int}", Delete)
                               .AddEndpointFilter<EnterpriseExistsFilter>()
                               .AddEndpointFilter<IsManagerAccessibleEnterpriseFilter>()
                               .WithName("DeleteEnterprise")
                               .Produces(StatusCodes.Status204NoContent)
                               .Produces(StatusCodes.Status404NotFound)
                               .Produces(StatusCodes.Status403Forbidden);
    }

    private static async Task<IResult> GetAll(EnterpriseQueryService enterpriseService, ClaimsPrincipal user)
    {
        List<EnterpriseViewModel> allEnterprises = await enterpriseService.GetAllAsync();

        return Results.Ok(allEnterprises.ForManager(user.GetManagerId()));
    }

    private static Task<IResult> GetById(int enterpriseId, HttpContext context)
    {
        EnterpriseViewModel enterprise = context.Items["Enterprise"] as EnterpriseViewModel ?? throw new InvalidOperationException("No enterprise found in the request.");

        return Task.FromResult(Results.Ok(enterprise));
    }

    private static async Task<IResult> Create(EnterpriseActionService enterpriseActionService, EnterpriseDTO enterpriseDto, HttpContext httpContext)
    {
        try
        {
            EnterpriseViewModel result = await enterpriseActionService.CreateAsync(enterpriseDto, httpContext.User.GetManagerId());

            return Results.Created($"/enterprises/{result.EnterpriseId}", result);
        }
        catch (NameIsTakenException)
        {
            return Results.Problem(statusCode: 400, title: "Company name must be unique.");
        }
        catch (VatIsTakenException)
        {
            return Results.Problem(statusCode: 400, title: "Company VAT must be unique.");
        }
    }

    private static async Task<IResult> Update(EnterpriseActionService enterpriseActionService, EnterpriseDTO enterpriseDto, int enterpriseId)
    {
        try
        {
            await enterpriseActionService.UpdateAsync(enterpriseDto, enterpriseId);

            return Results.NoContent();
        }
        catch (NameIsTakenException)
        {
            return Results.Problem(statusCode: 400, title: "Enterprise name must be unique.");
        }
        catch (VatIsTakenException)
        {
            return Results.Problem(statusCode: 400, title: "Enterprise VAT must be unique.");
        }
        catch (EnterpriseNotFoundException)
        {
            return Results.Problem(statusCode: 404, title: "Enterprise not found.");
        }
    }

    private static async Task<IResult> Delete(EnterpriseActionService enterpriseActionService, int enterpriseId)
    {
        try
        {
            await enterpriseActionService.DeleteAsync(enterpriseId);

            return Results.NoContent();
        }
        catch (EnterpriseNotFoundException)
        {
            return Results.Problem(statusCode: 404, title: "Enterprise not found.");
        }
    }

}