using LeonsList.Application.Exceptions;
using LeonsList.Application.Interfaces.Repositories;
using LeonsList.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeonsList.Application.Features.Pictures.Commands.DeletePictureById
{
    public class DeletePictureByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeletePictureByIdCommandHandler : IRequestHandler<DeletePictureByIdCommand, Response<int>>
        {
            private readonly IPictureRepositoryAsync _pictureRepository;
            public DeletePictureByIdCommandHandler(IPictureRepositoryAsync pictureRepository)
            {
                _pictureRepository = pictureRepository;
            }
            public async Task<Response<int>> Handle(DeletePictureByIdCommand command, CancellationToken cancellationToken)
            {
                var picture = await _pictureRepository.GetByIdAsync(command.Id);
                if (picture == null) throw new ApiException($"Picture Not Found.");
                picture.IsDeleted = true;
                await _pictureRepository.UpdateAsync(picture);
                return new Response<int>(picture.Id);
            }
        }
    }
}
