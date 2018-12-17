using AutoMapper;
using Northwind.Models;
using Northwind.Resources;

namespace Northwind.Api.Mappings
{
    public class NorthwindResourceProfile : Profile
    {
        public NorthwindResourceProfile()
        {
            ReverseMap<Category, CategoryResource>();
            ReverseMap<Customer, CustomerResource>();

            CreateMap<Employee, EmployeeResource>().
                ForMember(dest => dest.Manager, opt => opt.MapFrom(src => src.Manager.FirstName + " " + src.Manager.LastName));
            CreateMap<EmployeeResource, Employee>();

            CreateMap<Order, OrderResource>().
                ForMember(dest => dest.Shipper, opt => opt.MapFrom(src => src.Shipper.CompanyName)).
                ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.CompanyName))
                .ForMember(dest => dest.Representative,
                    opt => opt.MapFrom(src => src.Representative.FirstName + " " + src.Representative.LastName));
            CreateMap<Order, OrderResourceFull>().
                ForMember(dest => dest.Shipper, opt => opt.MapFrom(src => src.Shipper.CompanyName)).
                ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.CompanyName))
                .ForMember(dest => dest.Representative,
                    opt => opt.MapFrom(src => src.Representative.FirstName + " " + src.Representative.LastName));
            CreateMap<OrderResource, Order>();

            CreateMap<OrderDetail, OrderDetailResource>().
                ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Product.Category.CategoryName)).
                ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product.ProductName));

            CreateMap<Product, ProductResource>().
                ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.CategoryName)).
                ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.Supplier.CompanyName));
        }

        private void ReverseMap<TEntity, TResource>()
        {
            CreateMap<TEntity, TResource>();
            CreateMap<TResource, TEntity>();
        }
    }
}