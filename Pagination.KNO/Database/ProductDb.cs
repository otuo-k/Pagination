using Pagination.KNO.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pagination.KNO.Database
{
    public static class ProductDb
    {
        public static IQueryable<Product> GetAllProducts()
        {
            return new List<Product>
            {
                new Product{Id = 1, Name = "Product1"},
                new Product{Id = 2, Name = "Product2"}, 
                new Product{Id = 3, Name = "Product3"},
                new Product{Id = 4, Name = "Product4"},
                new Product{Id = 5, Name = "Product5"},
                new Product{Id = 6, Name = "Product6"},
                new Product{Id = 7, Name = "Product7"},
                new Product{Id = 8, Name = "Product8"},
                new Product{Id = 9, Name = "Product9"},
                new Product{Id = 10, Name = "Product10"},

                new Product{Id = 11, Name = "Product11"},
                new Product{Id = 12, Name = "Product12"},
                new Product{Id = 13, Name = "Product13"},
                new Product{Id = 14, Name = "Product14"},
                new Product{Id = 15, Name = "Product15"},
                new Product{Id = 16, Name = "Product16"},
                new Product{Id = 17, Name = "Product17"},
                new Product{Id = 18, Name = "Product18"},
                new Product{Id = 19, Name = "Product19"},
                new Product{Id = 20, Name = "Product20"},


                new Product{Id = 21, Name = "Product21"},
                new Product{Id = 22, Name = "Product22"},
                new Product{Id = 23, Name = "Product23"},
                new Product{Id = 24, Name = "Product24"},
                new Product{Id = 25, Name = "Product25"},
                new Product{Id = 26, Name = "Product26"},
                new Product{Id = 27, Name = "Product27"},
                new Product{Id = 28, Name = "Product28"},
                new Product{Id = 29, Name = "Product29"},
                new Product{Id = 30, Name = "Product30"},

                new Product{Id = 31, Name = "Product31"},
                new Product{Id = 32, Name = "Product32"},
                new Product{Id = 33, Name = "Product33"},
                new Product{Id = 34, Name = "Product34"},
                new Product{Id = 35, Name = "Product35"},
                new Product{Id = 36, Name = "Product36"},
                new Product{Id = 37, Name = "Product37"},
                new Product{Id = 38, Name = "Product38"},
                new Product{Id = 39, Name = "Product39"},
                new Product{Id = 40, Name = "Product40"},
            }.AsQueryable();
        }
    }
}
