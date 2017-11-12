using System;
using Application.Common;

namespace Application.Core.Commands
{
    public class UpdateProductOptionCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}