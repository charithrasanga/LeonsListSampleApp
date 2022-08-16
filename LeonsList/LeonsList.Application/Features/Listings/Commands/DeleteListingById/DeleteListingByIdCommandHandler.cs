using LeonsList.Application.Exceptions;
using LeonsList.Application.Interfaces.Repositories;
using LeonsList.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeonsList.Application.Features.Listings.Commands.DeleteListingById
{
    public class DeleteListingByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteListingByIdCommandHandler : IRequestHandler<DeleteListingByIdCommand, Response<int>>
        {
            private readonly IListingRepositoryAsync _ListingRepository;
            public DeleteListingByIdCommandHandler(IListingRepositoryAsync ListingRepository)
            {
                _ListingRepository = ListingRepository;
            }
            public async Task<Response<int>> Handle(DeleteListingByIdCommand command, CancellationToken cancellationToken)
            {
                var listing = await _ListingRepository.GetByIdAsync(command.Id);
                if (listing == null) throw new ApiException($"Listing Not Found.");
                await _ListingRepository.DeleteAsync(listing);
                return new Response<int>(listing.Id);
            }
        }
    }
}
