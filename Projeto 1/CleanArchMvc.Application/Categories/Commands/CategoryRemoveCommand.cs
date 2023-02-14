using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Categories.Commands
{
    public class CategoryRemoveCommand : IRequest<Category>
    {
        public int Id { get; set; }

        public CategoryRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
