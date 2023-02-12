using CleanArchMvc.Application.Categories.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Categories.Handlers
{
    public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryUpdateCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
                throw new ApplicationException($"Entity could not be found");
            else
            {
                category.Update(request.Name);

                return await _categoryRepository.UpdateAsync(category);
            }
        }
    }
}
