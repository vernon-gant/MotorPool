using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Services.Enterprise.Exceptions;
using MotorPool.Services.Enterprise.Models;

namespace MotorPool.Services.Enterprise.Services.Concrete;

public class DefaultEnterpriseActionService(AppDbContext dbContext, IMapper mapper) : EnterpriseActionService
{

    public async ValueTask<FullEnterpriseViewModel> CreateAsync(EnterpriseDTO enterpriseDTO, int managerId)
    {
        await EnsureNameAndVATAreUniqueAsync(enterpriseDTO.Name, enterpriseDTO.VAT);

        Domain.Enterprise newEnterprise = mapper.Map<Domain.Enterprise>(enterpriseDTO);

        newEnterprise.ManagerLinks.Add(new EnterpriseManager { ManagerId = managerId, EnterpriseId = newEnterprise.EnterpriseId });

        await dbContext.Enterprises.AddAsync(newEnterprise);

        await dbContext.SaveChangesAsync();

        return mapper.Map<FullEnterpriseViewModel>(newEnterprise);
    }

    public async ValueTask UpdateAsync(EnterpriseDTO enterpriseDTO, int enterpriseId)
    {
        await EnsureNameAndVATAreUniqueAsync(enterpriseDTO.Name, enterpriseDTO.VAT);

        Domain.Enterprise currentEnterprise = await dbContext.Enterprises.FindAsync(enterpriseId) ?? throw new EnterpriseNotFoundException("Enterprise not found");

        dbContext.Enterprises.Update(mapper.Map(enterpriseDTO, currentEnterprise));

        await dbContext.SaveChangesAsync();
    }

    public async ValueTask DeleteAsync(int enterpriseId)
    {
        Domain.Enterprise enterprise = await dbContext.Enterprises.FindAsync(enterpriseId) ?? throw new EnterpriseNotFoundException("Enterprise not found");

        dbContext.Enterprises.Remove(enterprise);

        await dbContext.SaveChangesAsync();
    }

    private async ValueTask EnsureNameAndVATAreUniqueAsync(string name, string VAT)
    {
        var nameAndVatSignatures = await dbContext.Enterprises.Select(e => new { e.Name, e.VAT }).ToListAsync();

        if (nameAndVatSignatures.Any(e => e.Name == name)) throw new NameIsTakenException("Name and VAT must be unique");

        if (nameAndVatSignatures.Any(e => e.VAT == VAT)) throw new NameIsTakenException("Name and VAT must be unique");
    }

}