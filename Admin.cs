using System;
namespace ШП_ЛБ6
{
	public class Admin
	{
        public int Id { get; set; }
        public string Email { get; set; }

        public Admin(int id, string email)
        {
            Id = id;
            Email = email;
        }

        public void AddProduct(List<Product> products, Product newProduct)
        {
            products.Add(newProduct);
        }

        public void UpdateProduct(Product product, string newTitle = null, string newDescription = null, double? newPrice = null, bool? newAvailability = null)
        {
            product.UpdateProduct(newTitle, newDescription, newPrice, newAvailability);
        }

        public void ViewProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine(product.GetProductDetails());
            }
        }
    }
}

