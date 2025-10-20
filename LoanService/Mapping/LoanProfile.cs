using AutoMapper;
using LoanService.Domain.Entities;

namespace LoanService.Mapping;

public class LoanProfile: Profile
{
    public LoanProfile()
    {
        CreateMap<Loan, LoanResponse>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
    }
}
