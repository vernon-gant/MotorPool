﻿using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Persistence;
using MotorPool.Services.VehicleBrand.Models;
using MotorPool.Services.VehicleBrand.ViewModels;

namespace MotorPool.Services.VehicleBrand.Services.Concrete;

public class DefaultVehicleBrandService(AppDbContext dbContext, IMapper mapper) : VehicleBrandService
{

    public async ValueTask<List<VehicleBrandSignatureWithId>> GetVehicleBrandsWithIdAsync()
    {
        return await dbContext.VehicleBrands
                              .OrderBy(vehicleBrand => vehicleBrand.CompanyName)
                              .Select(vehicleBrand => new VehicleBrandSignatureWithId
                              {
                                  VehicleBrandId = vehicleBrand.VehicleBrandId,
                                  BrandSignature = $"{vehicleBrand.CompanyName} - {vehicleBrand.ModelName}"
                              })
                              .AsNoTracking()
                              .ToListAsync();
    }

    public async ValueTask<List<VehicleBrandViewModel>> GetAllAsync()
    {
        var rawVehicleBrands = await dbContext.VehicleBrands.AsNoTracking().ToListAsync();

        return mapper.Map<List<VehicleBrandViewModel>>(rawVehicleBrands);
    }

}