using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common
{
    public class Entity : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; protected set; }
    }
}
