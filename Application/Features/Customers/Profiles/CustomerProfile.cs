using Application.Features.Customers.Commands.Create;
using AutoMapper;
using Domain.Entities;
using Application.Features.Dtos;


namespace Application.Features.Customers.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CreateCustomerCommand, Customer>().ReverseMap();


    }
}
