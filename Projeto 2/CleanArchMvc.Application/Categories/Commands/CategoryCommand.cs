using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Categories.Commands;

public abstract class CategoryCommand : IRequest<Category>
{
    public string Name { get; private set; }
}
