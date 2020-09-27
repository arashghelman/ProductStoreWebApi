using System;
using System.Collections.Generic;

namespace ProductStore.Models.DomainModels.EF.DTO
{
    public class Product
    {
        #region [- ctor -]

        public Product()
        {
        }
        #endregion

        #region [- props -]

        #region [- Id -]

        public int Id { get; set; }
        #endregion

        #region [- CategoryId -]

        public int CategoryId { get; set; }
        #endregion

        #region [- Name -]

        public string Name { get; set; }
        #endregion

        #region [- UnitsInStock -]

        public int UnitsInStock { get; set; }
        #endregion

        #region [- UnitPrice -]

        public decimal UnitPrice { get; set; }
        #endregion

        #region [- Discount -]

        public decimal Discount { get; set; }
        #endregion

        #region [- Photo -]

        public byte[] Photo { get; set; }
        #endregion

        #region [- Category -]

        public Category Category { get; set; }
        #endregion
        #endregion
    }
}
