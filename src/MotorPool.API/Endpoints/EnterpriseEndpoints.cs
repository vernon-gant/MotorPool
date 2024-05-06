using System.Security.Claims;
using AutoMapper;
using MotorPool.API.EndpointFilters;
using MotorPool.Domain;
using MotorPool.Repository.Enterprise;
using MotorPool.Services.Enterprise.Exceptions;
using MotorPool.Services.Enterprise.Models;
using MotorPool.Services.Manager;

namespace MotorPool.API.Endpoints;

public static class EnterpriseEndpoints
{

    public static void MapEnterpriseEndpoints(this IEndpointRouteBuilder managerResourcesGroupBuilder)
    {
        RouteGroupBuilder enterprisesGroupBuilder = managerResourcesGroupBuilder.MapGroup("enterprises");

        enterprisesGroupBuilder.MapGet("", GetAll)
                               .WithName("GetAllEnterprises")
                               .Produces<List<FullEnterpriseViewModel>>();

        enterprisesGroupBuilder.MapGet("{enterpriseId:int}", GetById)
                               .AddEndpointFilter<EnterpriseExistsFilter>()
                               .AddEndpointFilter<IsManagerAccessibleEnterpriseFilter>()
                               .WithName("GetEnterpriseById")
                               .Produces<FullEnterpriseViewModel>()
                               .Produces(StatusCodes.Status404NotFound)
                               .Produces(StatusCodes.Status403Forbidden);

        enterprisesGroupBuilder.MapPost("", Create)
                               .WithParameterValidation()
                               .WithName("CreateEnterprise")
                               .Produces<FullEnterpriseViewModel>()
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

    private static async Task<IResult> GetAll(EnterpriseQueryRepository enterpriseQueryRepository, ClaimsPrincipal user, IMapper mapper)
    {
        int managerId = user.GetManagerId();

        List<Enterprise> allEnterprises = await enterpriseQueryRepository.GetAllAsync(managerId);

        return Results.Ok(mapper.Map<List<FullEnterpriseViewModel>>(allEnterprises));
    }

    private static Task<IResult> GetById(int enterpriseId, HttpContext context)
    {
        FullEnterpriseViewModel fullEnterprise = context.Items["Enterprise"] as FullEnterpriseViewModel ?? throw new InvalidOperationException("No enterprise found in the request.");

        return Task.FromResult(Results.Ok(fullEnterprise));
    }

    private static async Task<IResult> Create(EnterpriseChangeRepository enterpriseChangeRepository, IMapper mapper, EnterpriseDTO enterpriseDto, HttpContext httpContext)
    {
        try
        {
            Enterprise newEnterprise = mapper.Map<Enterprise>(enterpriseDto);
            newEnterprise.ManagerLinks.Add(new EnterpriseManager
            {
                ManagerId = httpContext.User.GetManagerId()
            });
            await enterpriseChangeRepository.CreateAsync(newEnterprise);

            return Results.Created($"/enterprises/{newEnterprise.EnterpriseId}", mapper.Map<FullEnterpriseViewModel>(newEnterprise));
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

    private static async Task<IResult> Update(EnterpriseChangeRepository enterpriseChangeRepository, EnterpriseQueryRepository enterpriseQueryRepository, IMapper mapper, EnterpriseDTO enterpriseDto, int enterpriseId)
    {
        try
        {
            Enterprise? toUpdate = await enterpriseQueryRepository.GetByIdAsync(enterpriseDto.EnterpriseId);

            if (toUpdate is null) return Results.NotFound();

            await enterpriseChangeRepository.UpdateAsync(mapper.Map(enterpriseDto,toUpdate));

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

    private static async Task<IResult> Delete(EnterpriseChangeRepository enterpriseChangeRepository, int enterpriseId)
    {
        try
        {
            await enterpriseChangeRepository.DeleteAsync(enterpriseId);

            return Results.NoContent();
        }
        catch (EnterpriseNotFoundException)
        {
            return Results.Problem(statusCode: 404, title: "Enterprise not found.");
        }
    }

}