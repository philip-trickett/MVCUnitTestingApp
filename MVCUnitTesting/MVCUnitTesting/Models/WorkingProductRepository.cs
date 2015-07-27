using System.Collections.Generic;

namespace MVCUnitTesting.Models
{
    public class WorkingProductRepository : Repository
    {
        public List<Product> GetAll()
        {
            return new List<Product>()
            {
                new Product() {Genre = "Fiction", ID = 1, Name = "Moby Dick", Price = 12.50m},
                new Product() {Genre = "Fiction", ID = 2, Name = "War and Peace", Price = 17m},
                new Product() {Genre = "Non-Fiction", ID = 3, Name = "Chemistry", Price = 35m},
                new Product() {Genre = "Non-Fiction", ID = 4, Name = "Biology", Price = 35m},
                new Product() {Genre = "Fiction", ID = 5, Name = "Cryptonomicon", Price = 7m},
                new Product() {Genre = "Fiction", ID = 6, Name = "In Search of Lost Time", Price = 20m}
            };
        }
    }
}