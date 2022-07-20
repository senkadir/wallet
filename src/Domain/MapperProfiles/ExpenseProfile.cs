using AutoMapper;
using Domain.Models;
using Domain.Objects;

namespace Domain.MapperProfiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, ExpenseViewModel>();
        }
    }
}
