using System;
using Domain.Common;

namespace Domain.Core
{
    public class ProductOption: Entity
    {
        public ProductOption(Product product, string name, string description)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException(nameof(description));
            Product = product;
            Name = name;
            Description = description;
        }
        public Product Product { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public void UpdateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException(nameof(description));
            Description = description;
        }
        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            Name = name;
        }

        #region Do not use
        /// <summary>
        /// Ef requires empty ctor. Do not use
        /// </summary>
        [Obsolete]
        private ProductOption()
        {
            
        }

        #endregion
    }
}