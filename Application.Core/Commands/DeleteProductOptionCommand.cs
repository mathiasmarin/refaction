using System;
using Application.Common;

namespace Application.Core.Commands
{
    public class DeleteProductOptionCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}