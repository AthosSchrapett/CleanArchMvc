using CleanArchMvc.Application.Categories.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Categories.Handlers
{
    public class CategoryRemoveCommandHandler : IRequestHandler<CategoryRemoveCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryRemoveCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(CategoryRemoveCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if(category == null)
                throw new ApplicationException($"Entity could not be found");
            else
            {
                var result = await _categoryRepository.DeleteAsync(category);
                return result;
            }
        }
    }
}
