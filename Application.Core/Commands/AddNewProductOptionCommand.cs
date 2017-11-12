using System;
using Application.Common;

namespace Application.Core.Commands
{
    public class AddNewProductOptionCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProductId { get; set; }
    }
}