using CleanArchMvc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Categories.Commands
{
    public abstract class CategoryCommand : IRequest<Category>
    {
        public string Name { get; private set; }
    }
}
