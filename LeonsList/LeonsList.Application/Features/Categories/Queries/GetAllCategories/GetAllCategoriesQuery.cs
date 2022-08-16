﻿
using AutoMapper;
using LeonsList.Application.Interfaces.Repositories;
using LeonsList.Application.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LeonsList.Application.Features.Categories.Queries.GetAllCategories
{

    public class GetAllCategoriesQuery : IRequest<PagedResponse<IEnumerable<GetAllCategoriesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, PagedResponse<IEnumerable<GetAllCategoriesViewModel>>>
    {
        private readonly ICategoryRepositoryAsync _categoryRepository;
        private readonly IMapper _mapper;
        public GetAllCategoriesQueryHandler(ICategoryRepositoryAsync categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllCategoriesViewModel>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllCategoriesParameter>(request);
            var category = await _categoryRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var categoryViewModel = _mapper.Map<IEnumerable<GetAllCategoriesViewModel>>(category);
            return new PagedResponse<IEnumerable<GetAllCategoriesViewModel>>(categoryViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}