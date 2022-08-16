
using AutoMapper;
using LeonsList.Application.Interfaces.Repositories;
using LeonsList.Application.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LeonsList.Application.Features.Listings.Queries.GetAllListings
{

    public class GetAllListingsQuery : IRequest<PagedResponse<IEnumerable<GetAllListingsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllListingsQueryHandler : IRequestHandler<GetAllListingsQuery, PagedResponse<IEnumerable<GetAllListingsViewModel>>>
    {
        private readonly IListingRepositoryAsync _listingRepository;
        private readonly IPictureRepositoryAsync _pictureRepository;
        private readonly IMapper _mapper;
        public GetAllListingsQueryHandler(IListingRepositoryAsync listingRepository, IPictureRepositoryAsync pictureRepository, IMapper mapper)
        {
            _listingRepository = listingRepository;
            _pictureRepository = pictureRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllListingsViewModel>>> Handle(GetAllListingsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllListingsParameter>(request);
            var listings = await _listingRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);

            var listingViewModel = listings.Select(x => new GetAllListingsViewModel
            {
                Category = x.Category,
                Content = x.Content,
                Id = x.Id,
                IsPrivate = x.IsPrivate,
                Title = x.Title
            }).ToList();


            foreach (var item in listingViewModel)
            {

                item.imageIds = _pictureRepository.getListingImages(item.Id).ToList();
            }

            return new PagedResponse<IEnumerable<GetAllListingsViewModel>>(listingViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
