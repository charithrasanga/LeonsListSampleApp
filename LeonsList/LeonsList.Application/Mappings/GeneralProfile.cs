using AutoMapper;
using LeonsList.Application.Features.Categories.Commands.CreateCategory;
using LeonsList.Application.Features.Categories.Queries.GetAllCategories;
using LeonsList.Application.Features.Listings.Commands.CreateListing;
using LeonsList.Application.Features.Listings.Queries.GetAllListings;
using LeonsList.Domain.Entities;


namespace LeonsList.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {           
            // Category api mappings
            CreateMap<Category, GetAllCategoriesViewModel>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<GetAllCategoriesQuery, GetAllCategoriesParameter>();

            // Listing api mappings
            CreateMap<Listing, GetAllListingsViewModel>().ReverseMap();
            CreateMap<CreateListingCommand, Listing>();
            CreateMap<CreateAnonymousListingCommand, Listing>();
            CreateMap<GetAllListingsQuery, GetAllListingsParameter>();
        }
    }
}
