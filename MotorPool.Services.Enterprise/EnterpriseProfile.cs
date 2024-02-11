using AutoMapper;

using MotorPool.Services.Enterprise.Models;

namespace MotorPool.Services.Enterprise;

public class EnterpriseProfile : Profile
{

    public EnterpriseProfile()
    {
        CreateMap<Domain.Enterprise, EnterpriseViewModel>();
    }

}