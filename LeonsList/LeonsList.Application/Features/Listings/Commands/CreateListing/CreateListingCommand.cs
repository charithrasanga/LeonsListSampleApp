using AutoMapper;
using LeonsList.Application.Interfaces.Repositories;
using LeonsList.Application.Wrappers;
using LeonsList.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeonsList.Application.Features.Listings.Commands.CreateListing
{


    public partial class CreateListingCommand : IRequest<Response<int>>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int categoryId { get; set; }
        public bool IsPrivate { get; set; } = false;

        [DataType(DataType.Upload)]
        public List<IFormFile> Attachments { get; set; }

    }




    public class CreateListingCommandHandler : IRequestHandler<CreateListingCommand, Response<int>>
    {
        private readonly IListingRepositoryAsync _listingRepository;
        private readonly IPictureRepositoryAsync _pictureRepository;
        private readonly IMapper _mapper;
        public CreateListingCommandHandler(IListingRepositoryAsync listingRepository, IPictureRepositoryAsync pictureRepository, IMapper mapper)
        {
            _listingRepository = listingRepository;
            _pictureRepository = pictureRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateListingCommand request, CancellationToken cancellationToken)
        {
            var listing = _mapper.Map<Listing>(request);
            await _listingRepository.AddAsync(listing);


            foreach (var file in request.Attachments)
            {
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        Picture pic = new Picture();
                        pic.IsDeleted = false;
                        pic.Content = fileBytes;
                        pic.Listing = listing;
                        _ = await  _pictureRepository.AddAsync(pic);
                    }
                }
            }


            return new Response<int>(listing.Id);
        }
    }


}
