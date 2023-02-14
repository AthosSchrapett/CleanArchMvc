using CleanArchMvc.Application.Categories.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Categories.Handlers;

public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryCreateCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Name);

        if (category == null)
            throw new ApplicationException($"Error creating entity");
        else
        {
            return await _categoryRepository.CreateAsync(category);
        }
    }
}
