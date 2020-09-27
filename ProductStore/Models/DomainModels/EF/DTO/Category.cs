using System;
using System.Collections;
using System.Collections.Generic;

namespace ProductStore.Models.DomainModels.EF.DTO
{
    public class Category
    {
        #region [- ctor -]

        public Category()
        {
        }
        #endregion

        #region [- props -]

        #region [- Id -]

        public int Id { get; set; }
        #endregion

        #region [- Name -]

        public string Name { get; set; }
        #endregion

        #region [- Products -]

        public ICollection<Product> Products { get; set; }
        #endregion
        #endregion
    }
}
