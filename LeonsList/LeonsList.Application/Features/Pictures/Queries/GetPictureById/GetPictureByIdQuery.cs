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

namespace LeonsList.Application.Features.Categories.Queries.GetPictureById
{
    public class GetPictureByIdQuery : IRequest<Response<Picture>>
    {
        public int Id { get; set; }
        public class GetPictureByIdQueryHandler : IRequestHandler<GetPictureByIdQuery, Response<Picture>>
        {
            private readonly IPictureRepositoryAsync _pictureRepository;
            public GetPictureByIdQueryHandler(IPictureRepositoryAsync PictureRepository)
            {
                _pictureRepository = PictureRepository;
            }
            public async Task<Response<Picture>> Handle(GetPictureByIdQuery query, CancellationToken cancellationToken)
            {
                var picture = await _pictureRepository.GetByIdAsync(query.Id);
                if (picture == null) throw new ApiException($"Picture Not Found.");
                return new Response<Picture>(picture);
            }
        }
    }
}
