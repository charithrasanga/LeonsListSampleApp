﻿using LeonsList.Application.Exceptions;
using LeonsList.Application.Interfaces.Repositories;
using LeonsList.Application.Wrappers;
using LeonsList.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeonsList.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<Response<Category>>
    {
        public int Id { get; set; }
        public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Response<Category>>
        {
            private readonly ICategoryRepositoryAsync _categoryRepository;
            public GetCategoryByIdQueryHandler(ICategoryRepositoryAsync categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }
            public async Task<Response<Category>> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
            {
                var category = await _categoryRepository.GetByIdAsync(query.Id);
                if (category == null) throw new ApiException($"Category Not Found.");
                return new Response<Category>(category);
            }
        }
    }
}
