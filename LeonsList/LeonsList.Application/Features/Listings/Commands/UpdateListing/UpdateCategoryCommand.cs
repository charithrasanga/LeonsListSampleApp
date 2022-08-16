using LeonsList.Application.Exceptions;
using LeonsList.Application.Interfaces.Repositories;
using LeonsList.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeonsList.Application.Features.Listings.Commands.UpdateListing
{
    public class UpdateListingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public bool IsPrivate { get; set; } 

        public class UpdateListingCommandHandler : IRequestHandler<UpdateListingCommand, Response<int>>
        {
            private readonly IListingRepositoryAsync _listingRepository;
            private readonly ICategoryRepositoryAsync _categoryRepository;
            public UpdateListingCommandHandler(IListingRepositoryAsync listingRepository, ICategoryRepositoryAsync categoryRepository)
            {
                _listingRepository = listingRepository;
                _categoryRepository = categoryRepository;
            }
            public async Task<Response<int>> Handle(UpdateListingCommand command, CancellationToken cancellationToken)
            {
                var listing = await _listingRepository.GetByIdAsync(command.Id);

                if (listing == null)
                {
                    throw new ApiException($"Listing Not Found.");
                }
                else
                {

                    listing.Category = _categoryRepository.GetByIdAsync(command.CategoryId).Result;
                    listing.Title = command.Title;
                    listing.Content = command.Content;
                    listing.IsPrivate = command.IsPrivate;                 
                    await _listingRepository.UpdateAsync(listing);
                    return new Response<int>(listing.Id);
                }
            }
        }
    }
}
