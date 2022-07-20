using AutoMapper;
using Domain.Models;
using Domain.Objects;

namespace Domain.MapperProfiles
{
    public class PeriodProfile : Profile
    {
        public PeriodProfile()
        {
            CreateMap<Period, PeriodViewModel>();
        }
    }
}
