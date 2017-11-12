using System;
using Application.Common;

namespace Application.Core.Commands
{
    public class DeleteProductCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}