using LeonsList.Application.Exceptions;
using LeonsList.Application.Interfaces.Repositories;
using LeonsList.Application.Wrappers;
using LeonsList.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeonsList.Application.Features.Listings.Queries.GetListingById
{
    public class GetListingByIdQuery : IRequest<Response<Listing>>
    {
        public int Id { get; set; }
        public class GetListingByIdQueryHandler : IRequestHandler<GetListingByIdQuery, Response<Listing>>
        {
            private readonly IListingRepositoryAsync _listingRepository;
            public GetListingByIdQueryHandler(IListingRepositoryAsync listingRepository)
            {
                _listingRepository = listingRepository;
            }
            public async Task<Response<Listing>> Handle(GetListingByIdQuery query, CancellationToken cancellationToken)
            {
                var listing = await _listingRepository.GetByIdAsync(query.Id);
                if (listing == null) throw new ApiException($"Listing Not Found.");
                return new Response<Listing>(listing);
            }
        }
    }
}
