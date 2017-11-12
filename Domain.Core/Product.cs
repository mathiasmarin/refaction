using Domain.Common;
using System;

namespace Domain.Core
{
    public class Product: Entity
    {
        public Product(string name, string description, decimal price, decimal deliveryPrice)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException(nameof(description));
            Price = price;
            DeliveryPrice = deliveryPrice;
            Description = description;
            Name = name;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public decimal DeliveryPrice { get; private set; }
        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentNullException(nameof(newName));
            Name = newName;
        }
        public void UpdateDeliveryPrice(decimal newDeliveryPrice)
        {
            DeliveryPrice = newDeliveryPrice;
        }

        public void UpdateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException(nameof(description));
            Description = description;
        }

        public void UpdatePrice(decimal price)
        {
            Price = price;
        }
        #region Do not use

        /// <summary>
        /// EF requires empty ctor
        /// </summary>
        [Obsolete]
        private Product()
        {

        }

        #endregion


        
    }
}
