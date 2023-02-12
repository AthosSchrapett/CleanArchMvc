using CleanArchMvc.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CleanArchMvc.Application.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<IEnumerable<Category>>
    {
    }
}
