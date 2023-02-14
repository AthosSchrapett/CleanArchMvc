using AutoMapper;
using CleanArchMvc.Application.Categories.Commands;
using CleanArchMvc.Application.Categories.Queries;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CategoryService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task AddAsync(CategoryDTO categoryDTO)
    {
        var categoryCreateCommand = _mapper.Map<CategoryCreateCommand>(categoryDTO);
        await _mediator.Send(categoryCreateCommand);
    }

    public async Task<CategoryDTO> GetByIdAsync(int? id)
    {
        var categoryByIdQuery = new GetCategoryByIdQuery(id.Value);

        if (categoryByIdQuery == null)
            throw new Exception($"Entity could not be loaded.");

        var result = await _mediator.Send(categoryByIdQuery);

        return _mapper.Map<CategoryDTO>(result);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
    {
        var categoriesQuery = new GetCategoriesQuery();

        if (categoriesQuery == null)
            throw new Exception($"Entity could not be loaded.");

        var result = await _mediator.Send(categoriesQuery);

        return _mapper.Map<IEnumerable<CategoryDTO>>(result);
    }

    public async Task UpdateAsync(CategoryDTO categoryDTO)
    {
        var categoryUpdateCommand = _mapper.Map<CategoryUpdateCommand>(categoryDTO);
        await _mediator.Send(categoryUpdateCommand);
    }

    public async Task DeleteAsync(int? id)
    {
        var categoryRemoveCommand = new CategoryRemoveCommand(id.Value);

        if (categoryRemoveCommand == null)
            throw new Exception($"Entity could not be loaded.");

        await _mediator.Send(categoryRemoveCommand);
    }
}
