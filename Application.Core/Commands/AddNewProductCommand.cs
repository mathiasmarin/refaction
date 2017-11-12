using Application.Common;

namespace Application.Core.Commands
{
    public class AddNewProductCommand:ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
    }
}
