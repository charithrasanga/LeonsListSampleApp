using AutoMapper;
using LeonsList.Application.Interfaces.Repositories;
using LeonsList.Application.Wrappers;
using LeonsList.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeonsList.Application.Features.Categories.Commands.CreateCategory
{


    public partial class CreateCategoryCommand :IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }




    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Response<int>>
    {
        private readonly ICategoryRepositoryAsync _categoryRepository;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(ICategoryRepositoryAsync categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<LeonsList.Domain.Entities.Category>(request);
            await _categoryRepository.AddAsync(category);
            return new Response<int>(category.Id);
        }
    }




}
